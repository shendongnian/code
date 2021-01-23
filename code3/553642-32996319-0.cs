    public enum DirectionSwiped
    {
        None,
        Up,
        Down,
        Left,
        Right
    }
    public class SwipeEventArgs : EventArgs
    {
        public DirectionSwiped Direction { get; set; }
        public int NumberOfTouches { get; set; }
    }
    public class SwipeGestureDetector
    {
        public EventHandler<SwipeEventArgs> SwipeDetected;
        // How much of the grid needs to be covered by the swipe?
        private const double SWIPE_THRESHOLD = 0.5;
        // How much drift is allowed in the opposite axis?
        private const int ALLOWED_DRIFT = 100;
        Windows.Devices.Input.TouchCapabilities SupportedContacts = new Windows.Devices.Input.TouchCapabilities();
        uint numActiveContacts;
        Dictionary<uint, Windows.UI.Input.PointerPoint> contacts;
        Dictionary<uint, Point> startLocation;
        Dictionary<uint, DirectionSwiped> pointSwiped;
        private Grid mGrid;
        public SwipeGestureDetector(Grid grid)
        {
            mGrid = grid;
            numActiveContacts = 0;
            contacts = new Dictionary<uint, Windows.UI.Input.PointerPoint>((int)SupportedContacts.Contacts);
            startLocation = new Dictionary<uint, Point>((int)SupportedContacts.Contacts);
            pointSwiped = new Dictionary<uint, DirectionSwiped>((int)SupportedContacts.Contacts);
            grid.PointerPressed += new PointerEventHandler(Grid_PointerPressed);
            grid.PointerEntered += new PointerEventHandler(Grid_PointerEntered);
            grid.PointerReleased += new PointerEventHandler(Grid_PointerReleased);
            grid.PointerExited += new PointerEventHandler(Grid_PointerExited);
            grid.PointerCanceled += new PointerEventHandler(Grid_PointerCanceled);
            grid.PointerCaptureLost += new PointerEventHandler(Grid_PointerCaptureLost);
            grid.PointerMoved += new PointerEventHandler(Grid_PointerMoved);
        }
        // PointerPressed and PointerReleased events do not always occur in pairs. 
        // Your app should listen for and handle any event that might conclude a pointer down action 
        // (such as PointerExited, PointerCanceled, and PointerCaptureLost).
        void Grid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (Convert.ToBoolean(SupportedContacts.TouchPresent) && (numActiveContacts > SupportedContacts.Contacts))
            {
                // cannot support more contacts
                Debug.WriteLine("\nNumber of contacts exceeds the number supported by the device.");
                return;
            }
            Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(mGrid);
            // Check if pointer already exists (if enter occurred prior to down).
            if (contacts.ContainsKey(pt.PointerId))
            {
                return;
            }
            contacts[pt.PointerId] = pt;
            startLocation[pt.PointerId] = pt.Position;
            pointSwiped[pt.PointerId] = DirectionSwiped.None;
            ++numActiveContacts;
            e.Handled = true;
        }
        private void Grid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(mGrid);
            // Check if pointer already exists (if enter occurred prior to down).
            if (contacts.ContainsKey(pt.PointerId))
            {
                return;
            }
            // Push new pointer Id onto expando target pointers array.
            contacts[pt.PointerId] = pt;
            startLocation[pt.PointerId] = pt.Position;
            pointSwiped[pt.PointerId] = DirectionSwiped.None;
            ++numActiveContacts;
            e.Handled = true;
        }
        // Fires for for various reasons, including: 
        //    - User interactions
        //    - Programmatic caputre of another pointer
        //    - Captured pointer was deliberately released
        // PointerCaptureLost can fire instead of PointerReleased. 
        private void Grid_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(mGrid);
            if (contacts.ContainsKey(pt.PointerId))
            {
                checkSwipe();
                contacts[pt.PointerId] = null;
                contacts.Remove(pt.PointerId);
                startLocation.Remove(pt.PointerId);
                if (pointSwiped.ContainsKey(pt.PointerId))
                    pointSwiped.Remove(pt.PointerId);
                --numActiveContacts;
            }
            e.Handled = true;
        }
        // Fires for for various reasons, including: 
        //    - A touch contact is canceled by a pen coming into range of the surface.
        //    - The device doesn't report an active contact for more than 100ms.
        //    - The desktop is locked or the user logged off. 
        //    - The number of simultaneous contacts exceeded the number supported by the device.
        private void Grid_PointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(mGrid);
            if (contacts.ContainsKey(pt.PointerId))
            {
                checkSwipe();
                contacts[pt.PointerId] = null;
                contacts.Remove(pt.PointerId);
                startLocation.Remove(pt.PointerId);
                if (pointSwiped.ContainsKey(pt.PointerId))
                    pointSwiped.Remove(pt.PointerId);
                --numActiveContacts;
            }
            e.Handled = true;
        }
        private void Grid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(mGrid);
            if (contacts.ContainsKey(pt.PointerId))
            {
                checkSwipe();
                contacts[pt.PointerId] = null;
                contacts.Remove(pt.PointerId);
                startLocation.Remove(pt.PointerId);
                if (pointSwiped.ContainsKey(pt.PointerId))
                    pointSwiped.Remove(pt.PointerId);
                --numActiveContacts;
            }
            e.Handled = true;
        }
        void Grid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(mGrid);
            if (contacts.ContainsKey(pt.PointerId))
            {
                checkSwipe();
                contacts[pt.PointerId] = null;
                contacts.Remove(pt.PointerId);
                startLocation.Remove(pt.PointerId);
                if (pointSwiped.ContainsKey(pt.PointerId))
                    pointSwiped.Remove(pt.PointerId);
                --numActiveContacts;
            }
            e.Handled = true;
        }
        private void Grid_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Input.PointerPoint currentPoint = e.GetCurrentPoint(mGrid);
            if (currentPoint.IsInContact)
            {
                if (startLocation.ContainsKey(currentPoint.PointerId))
                {
                    Point startPoint = startLocation[currentPoint.PointerId];
                    // Compare startPoint to current location and determine if that point did a swipe?
                    double horizontalMovement = currentPoint.Position.X - startPoint.X;
                    double verticalMovement = currentPoint.Position.Y - startPoint.Y;
                    double horizontalDistance = Math.Abs(horizontalMovement);
                    double verticalDistance = Math.Abs(verticalMovement);
                    double requiredLeftMovement = mGrid.ActualWidth * SWIPE_THRESHOLD * -1;
                    double requiredRightMovement = mGrid.ActualWidth * SWIPE_THRESHOLD;
                    double requiredUpMovement = mGrid.ActualHeight * SWIPE_THRESHOLD * -1;
                    double requiredDownMovement = mGrid.ActualHeight * SWIPE_THRESHOLD;
                    if (verticalMovement < requiredUpMovement && horizontalDistance < 100)
                    {
                        pointSwiped[currentPoint.PointerId] = DirectionSwiped.Up;
                    }
                    else if (verticalMovement > requiredDownMovement && horizontalDistance < ALLOWED_DRIFT)
                    {
                        pointSwiped[currentPoint.PointerId] = DirectionSwiped.Down;
                    }
                    else if (horizontalMovement > requiredRightMovement && verticalDistance < ALLOWED_DRIFT)
                    {
                        pointSwiped[currentPoint.PointerId] = DirectionSwiped.Right;
                    }
                    else if (horizontalMovement < requiredLeftMovement && verticalDistance < ALLOWED_DRIFT)
                    {
                        pointSwiped[currentPoint.PointerId] = DirectionSwiped.Left;
                    }
                }
            }
        }
        void checkSwipe()
        {
            NotififyListenerIfSwiped(DirectionSwiped.Up);
            NotififyListenerIfSwiped(DirectionSwiped.Down);
            NotififyListenerIfSwiped(DirectionSwiped.Left);
            NotififyListenerIfSwiped(DirectionSwiped.Right);
        }
        private void NotififyListenerIfSwiped(DirectionSwiped direction)
        {
            int fingers = numberOfSwipedFingers(direction);
            if (fingers >= 1)
            {
                if (SwipeDetected != null)
                {
                    SwipeDetected(this, new SwipeEventArgs() { Direction = direction, NumberOfTouches = fingers });
                }
            }
            if (fingers > 0)
                pointSwiped.Clear();
        }
        int numberOfSwipedFingers(DirectionSwiped direction)
        {
            int count = 0;
            foreach (var item in pointSwiped)
            {
                DirectionSwiped swipe = item.Value;
                if (swipe == direction)
                {
                    count += 1;
                }
            }
            return count;
        }
    }
