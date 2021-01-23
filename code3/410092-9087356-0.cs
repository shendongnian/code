            private void GenerateFontMap(string PathTofont, int GlyphsPerRow, int WidthAndHeight)       
            {
            GlyphTypeface font = new GlyphTypeface(new Uri(PathTofont));
            List<ushort> fontNum = new List<ushort>();
            foreach (KeyValuePair<int, ushort> kvp in font.CharacterToGlyphMap)
            {
                fontNum.Add(kvp.Value);
            }
            if (fontNum.Count > 0)
            {
                int mapWidth = WidthAndHeight * GlyphsPerRow;
                int mapHeight = WidthAndHeight * ((fontNum.Count + 1) / GlyphsPerRow + 1);
                Bitmap b = new Bitmap(mapWidth, mapHeight);
                Graphics g = Graphics.FromImage(b);
                System.Windows.Media.Pen glyphPen = new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 1);
                Geometry glyphGeometry;
                GeometryDrawing glyphDrawing;
                PngBitmapEncoder encoder;
                RenderTargetBitmap bmp;
                DrawingVisual viz;
                for (int i = 0; i < fontNum.Count; i++)
                {                    
                    glyphGeometry = font.GetGlyphOutline(fontNum[i], WidthAndHeight, 1);
                    glyphDrawing = new GeometryDrawing(System.Windows.Media.Brushes.Black, glyphPen, glyphGeometry);
                    DrawingImage geometryImage = new DrawingImage(glyphDrawing);
                    geometryImage.Freeze();
                    viz = new DrawingVisual();
                    DrawingContext dc = viz.RenderOpen();
                    dc.DrawImage(geometryImage, new Rect(0, 0, geometryImage.Width, geometryImage.Height));
                    dc.Close();
                    bmp = new RenderTargetBitmap(WidthAndHeight, WidthAndHeight, 96, 96, PixelFormats.Pbgra32);
                    bmp.Render(viz);
                    encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bmp));
                    MemoryStream myStream = new MemoryStream();
                    encoder.Save(myStream);
                    g.DrawImage(System.Drawing.Bitmap.FromStream(myStream), new PointF((i - (i / GlyphsPerRow) * GlyphsPerRow) * WidthAndHeight, i / GlyphsPerRow * WidthAndHeight));
                }
                g.Dispose();
                b.Save("map.png", ImageFormat.Png);
                b.Dispose();
            }
        }
