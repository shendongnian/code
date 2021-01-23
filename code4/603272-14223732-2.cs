        public static bool SharedColumn(this MeshGeometry3D basis, MeshGeometry3D compareTo, Vector3D normal)
        {
            foreach (Point3D basePt in basis.Positions)
            {
                foreach (Point3D compPt in compareTo.Positions)
                {
                    var compToBasis = basePt - compPt; // vector from compare point to basis point
                    if (normal.SSDifference(compToBasis) < float.Epsilon) // at least one will be same direction as
                    {                                                     // as normal if they are shared in a column
                        return true;
                    }
                }
            }
            return false;
        }
