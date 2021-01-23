        public static class GridGenerator
        {
            public static void CreateGridBackground()
            {
    
                DrawingVisual visual = new DrawingVisual();
                DrawingContext context = visual.RenderOpen();
                context.DrawRectangle(Brushes.Red, null, new Rect(0, 0, 256, 512));
                for (int xRow = 0; xRow < 256 / 16; xRow++)
                {
                    for (int yColumn = 0; yColumn < 512 / 16; yColumn++)
                    {
                        if ((yColumn % 2 == 0 && xRow % 2 == 0) || (yColumn % 2 != 0 && xRow % 2 != 0))
                        {
                            context.DrawRectangle(Brushes.White, null, new Rect(xRow * 16, yColumn * 16, 16, 16));
                        }
                    }
                }
                context.Close();
    
                RenderTargetBitmap bmp = new RenderTargetBitmap(256, 512, 96, 96, PixelFormats.Pbgra32);
                bmp.Render(visual);
    
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(new FileStream("C:/Users/Krythic/Desktop/Test.png", FileMode.Create));
            }
        }
