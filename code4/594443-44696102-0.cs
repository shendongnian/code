        private bool isInside(DbGeography polygon, double longitude, double latitude)
        {
            DbGeography point = DbGeography.FromText(string.Format("POINT({1} {0})", latitude.ToString().Replace(',', '.'), longitude.ToString().Replace(',','.')), DbGeography.DefaultCoordinateSystemId);
            // If the polygon area is larger than an earth hemisphere (510 Trillion m2 / 2), we know it needs to be fixed
            if (polygon.Area.HasValue && polygon.Area.Value > 255000000000000L)
            {
                // Convert our DbGeography polygon into a SqlGeography object for the ReorientObject() call
                SqlGeography sqlPolygon = SqlGeography.STGeomFromWKB(new System.Data.SqlTypes.SqlBytes(polygon.AsBinary()), DbGeography.DefaultCoordinateSystemId);
                // ReorientObject will flip the polygon so the outside becomes the inside
                sqlPolygon = sqlPolygon.ReorientObject();
                // Convert the SqlGeography object back into a WKT string
                polygon = DbGeography.FromBinary(sqlPolygon.STAsBinary().Value);
            }
            return point.Intersects(polygon);
        }
