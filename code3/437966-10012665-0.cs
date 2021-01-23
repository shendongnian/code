            UserControl userControl = pane.Content;
            ContentPresenter visualParent = (VisualTreeHelper.GetParent(userControl) as ContentPresenter);
            double oldWidth = visualParent.Width;
            double oldHeight = visualParent.Height;
            visualParent.Width = BitmapImageWidth;
            visualParent.Height = BitmapImageHeight;
            visualParent.UpdateLayout(); // This is required! To apply the change in Width and Height
            WriteableBitmap bmp = new WriteableBitmap(BitmapImageWidth, BitmapImageHeight);
            bmp.Render(userControl, null);
            bmp.Invalidate(); // Only once you Invalidate is the Control actually rendered to the bmp
            RadBitmap radImage = new RadBitmap(bmp);
            visualParent.Width = oldWidth; // Revert back to original size
            visualParent.Height = oldHeight; // Revert back to original size
            return new PngFormatProvider().Export(radImage); // returns the Image as a png encoded Byte Array
