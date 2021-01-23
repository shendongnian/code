            Texture2D maskTexture = helper.CreateRenderTexture(width, height);
            RenderTargetProperties props = new RenderTargetProperties
            {
                HorizontalDpi = 96,
                PixelFormat = new PixelFormat(SlimDX.DXGI.Format.Unknown, AlphaMode.Premultiplied),
                Type = RenderTargetType.Default,
                Usage = RenderTargetUsage.None,
                VerticalDpi = 96,
            };
            using (SlimDX.Direct2D.Factory factory = new SlimDX.Direct2D.Factory())
            using (SlimDX.DXGI.Surface surface = maskTexture.AsSurface())
            using (RenderTarget target = RenderTarget.FromDXGI(factory, surface, props))
            using (SlimDX.Direct2D.Brush brush = new SolidColorBrush(target, new SlimDX.Color4(System.Drawing.Color.Red)))
            using (PathGeometry geometry = new PathGeometry(factory))
            using (SimplifiedGeometrySink sink = geometry.Open())
            {
                foreach (Polygon polygon in mask.Polygons)
                {
                    PointF[] points = new PointF[polygon.Points.Count()];
                    int i = 0;
                    foreach (Vector2 p in polygon.Points)
                    {
                        points[i++] = new PointF(p.X * width, p.Y * height);
                    }
                    sink.BeginFigure(points[0], FigureBegin.Filled);
                    sink.AddLines(points);
                    sink.EndFigure(FigureEnd.Closed);
                }
                sink.Close();
                target.BeginDraw();
                target.FillGeometry(geometry, brush);
                target.EndDraw();
            }
