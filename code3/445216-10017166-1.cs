        private static void CaptureScreen(Screen window, string file)
        {
            try
            {
                Rectangle s_rect = window.WorkingArea;
                using (Bitmap bmp = new Bitmap(s_rect.Width, s_rect.Height))
                {
                    using (Graphics gScreen = Graphics.FromImage(bmp))
                        gScreen.CopyFromScreen(s_rect.Location, Point.Empty, s_rect.Size);
                    bmp.Save(file, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            catch (Exception) { /*TODO: Any exception handling.*/ }
        }
