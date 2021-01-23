        public bool PointInShape() {
            // Load a shapefile.  If the shapefile is already using your custom projection, we don't need to change it.
            Shapefile wierdShapefile = Shapefile.OpenFile("C:\\MyShapefile.shp");
            
            // Note, if your shapefile with custom projection has a .prj file, then we don't need to mess with defining the projection.
            // If not, we can define the projection as follows:
            
            // First get a ProjectionInfo class for the normal UTM projection
            ProjectionInfo pInfo = DotSpatial.Projections.KnownCoordinateSystems.Projected.UtmNad1983.NAD1983UTMZone10N;
            
            // Next modify the pINfo with your custom False Northing
            pInfo.FalseNorthing = 400000;
            wierdShapefile.Projection = pInfo;
            // Reproject the strange shapefile so that it is in latitude/longitude coordinates
            wierdShapefile.Reproject(DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984);
            // Define the WGS84 Lat Lon point to test
            Coordinate test = new Coordinate(-120, 40);
            foreach (Feature f in wierdShapefile.Features) {
                Polygon pg = f.BasicGeometry as Polygon;
                if (pg != null)
                {
                    if (pg.Contains(new Point(test)))
                    {
                        // If the point is inside one of the polygon features
                        return true;
                    }
                }
                else {
                    // If you have a multi-part polygon then this should also handle holes I think
                    MultiPolygon polygons = f.BasicGeometry as MultiPolygon;
                    if (polygons.Contains(new Point(test))) {
                        return true;
                    }
                }
            }
            return false;
        }
