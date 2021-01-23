        // controls "swipe" behavior
        private Point touchDownPosition;  // last position of touch down
        private int touchDownTime;        // last time of touch down
        private int touchUpTime;          // last time of touch up
        private int swipeMaxTime = 1000;  // time (in milliseconds) that a swipe must occur in
        private int swipeMinDistance = 25;// distance (in pixels) that a swipe must cover
        private int swipeMinBounceTime = 500; // time (in milliseconds) between multiple touch events (minimizes "bounce")
        // handler for touch events
        void Touch_FrameReported(object sender, TouchFrameEventArgs e) 
        {
            var item = MyPivot.SelectedItem as PivotItem;
            // ignore touch if we are not on the browser pivot item
            if (item != BrowserPivotItem) 
                return;
            var point = e.GetPrimaryTouchPoint(item);
            switch (point.Action) 
            {
                case TouchAction.Down:
                    touchDownTime = e.Timestamp;
                    touchDownPosition = point.Position;
                    touchUpTime = 0;
                    break;
                case TouchAction.Up:
                    // often multiple touch up events are fired, ignore re-fired events
                    if (touchUpTime != 0 && touchUpTime - e.Timestamp < swipeMinBounceTime)
                        return;
                    touchUpTime = e.Timestamp;
                    var xDelta = point.Position.X - touchDownPosition.X;
                    var yDelta = point.Position.Y - touchDownPosition.Y;
                    // ensure touch event meets the requirements for a "swipe"
                    if (touchUpTime - touchDownTime < swipeMaxTime && Math.Abs(xDelta) > swipeMinDistance && Math.Abs(xDelta) > Math.Abs(yDelta)) 
                    {
                        // advance to next pivot item depending on swipe direction
                        var iNext = MyPivot.SelectedIndex + (delta > 0 ? -1 : 1);
                        iNext = iNext < 0 || iNext == MyPivot.Items.Count ? 0 : iNext;
                        MyPivot.SelectedIndex = iNext;
                    }
                    break;
            }
        }
