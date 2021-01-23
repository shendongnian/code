        public static void TakeScreenshot(Panel panel, string filePath)
        {
            if (panel == null)
                throw new ArgumentNullException("panel");
            if (filePath == null)
                throw new ArgumentNullException("filePath");
            // get parent form (may not be a direct parent)
            Form form = panel.FindForm();
            if (form == null)
                throw new ArgumentException(null, "panel");
            // remember form position
            int w = form.Width;
            int h = form.Height;
            int l = form.Left;
            int t = form.Top;
            // get panel virtual size
            Rectangle display = panel.DisplayRectangle;
            // get panel position relative to parent form
            Point panelLocation = panel.PointToScreen(panel.Location);
            Size panelPosition = new Size(panelLocation.X - form.Location.X, panelLocation.Y - form.Location.Y);
            // resize form and move it outside the screen
            int neededWidth = panelPosition.Width + display.Width;
            int neededHeight = panelPosition.Height + display.Height;
            form.SetBounds(0, -neededHeight, neededWidth, neededHeight, BoundsSpecified.All);
            // resize panel (useless if panel has a dock)
            int pw = panel.Width;
            int ph = panel.Height;
            panel.SetBounds(0, 0, display.Width, display.Height, BoundsSpecified.Size);
            // render the panel on a bitmap
            try
            {
                Bitmap bmp = new Bitmap(display.Width, display.Height);
                panel.DrawToBitmap(bmp, display);
                bmp.Save(filePath);
            }
            finally
            {
                // restore
                panel.SetBounds(0, 0, pw, ph, BoundsSpecified.Size);
                form.SetBounds(l, t, w, h, BoundsSpecified.All);
            }
        }
