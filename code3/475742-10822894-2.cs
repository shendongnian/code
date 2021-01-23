    System.Windows.Ink.Stroke newStroke = null;
        
        private void inkPresenterSample_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            inkPresenterSample.CaptureMouse();
            //get mouse position and add first point to a new line to be drawn
            var mousePosition = e.GetPosition(inkPresenterSample);
            var stylusStartPoint = new StylusPointCollection();
            stylusStartPoint.Add(new StylusPoint(mousePosition.X, mousePosition.Y));
            //set line's attributes, it real application this should be probably done outside this method
            var drawingAttributes = new System.Windows.Ink.DrawingAttributes();
            //IMPORTANT: semi-transparent color is used, so the opacity effect is visible
            drawingAttributes.Color = System.Windows.Media.Color.FromArgb(110, 0, 0, 0);
            drawingAttributes.Width = 10;
            //create a new stroke to be drawn
            newStroke = new System.Windows.Ink.Stroke(stylusStartPoint, drawingAttributes);
            newStroke.StylusPoints.Add(new StylusPoint(mousePosition.X, mousePosition.Y));
            
            //add reference to a new stroke to the InkPresenter control
            inkPresenterSample.Strokes.Add(newStroke);
        }
        private void inkPresenterSample_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            inkPresenterSample.ReleaseMouseCapture();
            if (newStroke != null)
            {
                newStroke = null;
            }
        }
        private void inkPresenterSample_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            //if a stroke is currently drawn in the InkPresenter
            if (newStroke != null)
            {
                //add a new point to the stroke
                var mousePosition = e.GetPosition(inkPresenterSample);
                newStroke.StylusPoints.Add(new StylusPoint(mousePosition.X, mousePosition.Y));
            }
        }
