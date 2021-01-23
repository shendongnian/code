    class MouseTracker
    {
        private Point _prevMousePosition = new Point(0, 0);
        //Maybe define some higher-level events here
        public event ... MouseMoveWithHistory;
        public void HandleMouseMove(object sender, MouseEventArgs e)
        {
            if (_prevMousePosition == Cursor.Position) return;
            //Do stuff
            //Trigger higher level events
        }
    }
