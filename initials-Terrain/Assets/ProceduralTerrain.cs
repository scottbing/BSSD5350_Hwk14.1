using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ProceduralTerrain : MonoBehaviour
{
    [SerializeField]
    int xWidth = 30;
    [SerializeField]
    int zDepth = 30;

    Vector3[] vertices;
    Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        //he says the width and depth are a vertex count not a square count 
        //his code is wrong when he adds 1, but if you do want to change it 
        //so the depth is number of squares created not numebr of vertices,
        //uncomment the next 2 lines
        xWidth += 1;
        zDepth += 1;
        CreateGeometry();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateGeometry() {
        int verticeCounter = 0;

        vertices = new Vector3[(xWidth) * (zDepth)];
        for (int x = 0; x < xWidth; x++)
        {
             for (int z = 0; z < zDepth; z++)
            {
                vertices[verticeCounter] = new Vector3(x, 1.0f, z);     verticeCounter++;
                verticeCounter++;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (vertices == null) return;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .5f);
        }
    }
}