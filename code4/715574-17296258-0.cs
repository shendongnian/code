     private void button_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            button.CaptureMouse();
        }
        private void button_PreviewMouseUp_1(object sender, MouseButtonEventArgs e)
        {
            button.ReleaseMouseCapture();
        }
        private void button_PreviewMouseMove_1(object sender, MouseEventArgs e)
        {
            if (button.IsMouseCaptured)
            {
                Canvas.SetLeft(button, e.GetPosition(this).X);
                Canvas.SetTop(button, e.GetPosition(this).Y);
            }
        }
