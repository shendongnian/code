        public static void SaveImage(Control control, string path)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                GenerateImage(element, stream);
                Image img = Image.FromStream(stream);
                img.Save(path);
            }
        }
        public static void GenerateImage(Control control, Stream result)
        {
            //Set background to white
            control.Background = Brushes.White;
            Size controlSize = RetrieveDesiredSize(control);
            Rect rect = new Rect(0, 0, controlSize.Width, controlSize.Height);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)controlSize.Width, (int)controlSize.Height, IMAGE_DPI, IMAGE_DPI, PixelFormats.Pbgra32);
            control.Arrange(rect);
            rtb.Render(control);
            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(rtb));
            png.Save(result);
        }
        private static Size RetrieveDesiredSize(Control control)
        {
            control.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            return control.DesiredSize;
        }
