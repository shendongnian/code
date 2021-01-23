    public static class GeometricExtensions3D
    {
        public static Vector3D FaceNormal(this MeshGeometry3D geo)
        {
            // get first triangle's positions
            var ptA = geo.Positions[geo.TriangleIndices[0]];
            var ptB = geo.Positions[geo.TriangleIndices[1]];
            var ptC = geo.Positions[geo.TriangleIndices[2]];
            // get specific vectors for right-hand normalization
            var vecAB = ptB - ptA;
            var vecBC = ptC - ptB;
            // normal is cross product
            var normal = Vector3D.CrossProduct(vecAB, vecBC);
            // unit vector for cleanliness
            normal.Normalize();
            return normal;
        }
    }   
