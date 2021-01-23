        private void printDocument1_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e) {
            e.PageSettings.Landscape = true;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            // Make screenshot
            var scr = Screen.FromPoint(this.Location);
            using (var bmp = new Bitmap(scr.Bounds.Width, scr.Bounds.Height)) {
                using (var gr = Graphics.FromImage(bmp)) {
                    gr.CopyFromScreen(new Point(scr.Bounds.Left, scr.Bounds.Top), Point.Empty, bmp.Size);
                }
                // Determine scaling
                float scale = 1.0f;
                scale = Math.Min(scale, (float)e.MarginBounds.Width / bmp.Width);
                scale = Math.Min(scale, (float)e.MarginBounds.Height / bmp.Height);
                // Set scaling and offset
                e.Graphics.TranslateTransform(e.MarginBounds.Left + (e.MarginBounds.Width - bmp.Width * scale) / 2, 
                                              e.MarginBounds.Top + (e.MarginBounds.Height - bmp.Height * scale) / 2);
                e.Graphics.ScaleTransform(scale, scale);
                // And draw
                e.Graphics.DrawImage(bmp, 0, 0);
            }
        }
