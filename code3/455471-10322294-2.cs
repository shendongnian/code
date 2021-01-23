            StreamGeometry geometry = new StreamGeometry();
            using (StreamGeometryContext ctx = geometry.Open())
            {
                foreach (Polygon polygon in mask.Polygons)
                {
                    bool first = true;
                    foreach (Vector2 p in polygon.Points)
                    {
                        Point point = new Point(p.X, p.Y);
                        if (first)
                        {
                            ctx.BeginFigure(point, true, true);
                            first = false;
                        }
                        else
                        {
                            ctx.LineTo(point, false, false);
                        }
                    }
                }
            }
