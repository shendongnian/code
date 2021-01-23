        bool isClicked = false;
        double rectPosition;        
        private void mouseDown(object sender, MouseButtonEventArgs e)
        {
            isClicked = true;
            rectPosition = e.GetPosition(null).X;
            rect.CaptureMouse();
        }
        private void mouseUp(object sender, MouseButtonEventArgs e)
        {
            isClicked = false;
        }
        private void mouseMove(object sender, MouseEventArgs e)
        {
            double position = e.GetPosition(null).X - rectPosition;
            double newPosition = position + (double)rect.GetValue(Canvas.LeftProperty);
            
            rect.SetValue(Canvas.LeftProperty, newPosition);
            rectPosition = e.GetPosition(null).X;
        }
