        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            _currentItemIndex++;//added index to keep track of page. default to 1
            appendedDocs.PageNumber = _currentItemIndex;//set to current page for printing
            XRect cropBox = appendedDocs.CropBox;
            double srcWidth = (cropBox.Width / 72) * 100;
            double srcHeight = (cropBox.Height / 72) * 100;
            double pageWidth = e.PageBounds.Width;
            double pageHeight = e.PageBounds.Height;
            double marginX = e.PageSettings.HardMarginX;
            double marginY = e.PageSettings.HardMarginY;
            
            //center it
            double x = (pageWidth - srcWidth) / 2;
            double y = (pageHeight - srcHeight) / 2;
            x -= marginX;
            y -= marginY;
            RectangleF rect = new RectangleF((float)x, (float)y, (float)srcWidth, (float)srcHeight);
            appendedDocs.Rect.SetRect(cropBox);
            int rez = e.PageSettings.PrinterResolution.X;
            appendedDocs.Rendering.DotsPerInch = rez;
            Graphics g = e.Graphics;
            
            using (Bitmap bitmap = appendedDocs.Rendering.GetBitmap())
            {
                g.DrawImage(bitmap, rect);
            }
            e.HasMorePages = _currentItemIndex < appendedDocs.PageCount;//check for more pages.
        }
