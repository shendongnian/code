    //set width and height of your choice
    RenderTargetBitmap bmp = null;
    //...
    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //initialize RenderTargetBitmap object
            bmp = new RenderTargetBitmap((int)this.ActualWidth, (int)this.ActualHeight, 90, 90, PixelFormats.Default);
            
            //set initialized bmp as image's source
            image.Source = bmp;
        }
        
        /// <summary>
        /// Helper method drawing a line.
        /// </summary>
        /// <param name="p1">Start point of the line to draw.</param>
        /// <param name="p2">End point of the line to draw.</param>
        /// <param name="pen">Pen to use to draw the line.</param>
        /// <param name="thickness">Thickness of the line to draw.</param>
        private void DrawLine(Point p1, Point p2, Pen pen, double thickness)
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                //set properties of the Pen object to make the line more smooth
                pen.Thickness = thickness;
                pen.StartLineCap = PenLineCap.Round;
                pen.EndLineCap = PenLineCap.Round;
                
                //write your drawing code here
                drawingContext.DrawLine(pen, p1, p2);
            }
        }
