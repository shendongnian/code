        foreach (MeshGeometry3D geo in taggedGeometries)
        {
            for (int i = 0; i < geo.Positions.Count; i++)
            {
                geo.Positions[i] *= matTrans;
            }
        }
