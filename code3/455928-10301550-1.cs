        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (posX < 0 || posX > this.Width || posY < 0 || posY > this.Height)
                this.Close();            
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            
            posX = p.X; // private double posX is a class member
            posY = p.Y; // private double posY is a class member
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            System.Windows.Input.Mouse.Capture(this, System.Windows.Input.CaptureMode.SubTree);
        }
