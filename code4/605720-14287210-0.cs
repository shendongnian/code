        public void SetImageCoordinate(double x, double y)
        {
            x += 60;
            TransformGroup transformGroup = (TransformGroup)image.RenderTransform;
            ScaleTransform transform = (ScaleTransform)transformGroup.Children[0];
            ImageSource imageSource = image.Source;
            BitmapImage bitmapImage = (BitmapImage) imageSource ;
            //Now since you got the image displayed in Image control. You can easily map the mouse position to the Pixel scale.
            var pixelMousePositionX = -(x ) / bitmapImage.PixelWidth * transform.ScaleX * image.ActualWidth;
            var pixelMousePositionY = -(y) / bitmapImage.PixelHeight * transform.ScaleY * image.ActualHeight;
            //MessageBox.Show("X: " + pixelMousePositionX + "; Y: " + pixelMousePositionY);
            var tt = (TranslateTransform)((TransformGroup)image.RenderTransform).Children.First(tr => tr is TranslateTransform);
            tt.X = pixelMousePositionX;
            tt.Y = pixelMousePositionY;            
        }
