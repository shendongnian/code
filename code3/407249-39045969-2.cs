    public static class ext
    {
        private static Point? _lastTapLocation;
        // Stopwatch changed to int
        private int _lastTimestamp = 0;
        public static bool IsDoubleTap(this StylusSystemGestureEventArgs e, IInputElement iInputElement)
        {
            Point currentTapPosition = e.GetPosition(iInputElement);
            bool tapsAreCloseInDistance = false;
            if (_lastTapLocation != null)
            {
                tapsAreCloseInDistance = GetDistanceBetweenPoints(currentTapPosition, (Point)_lastTapLocation) < 70;
            }
            _lastTapLocation = currentTapPosition;
            // This replaces the previous TimeSpan calculation
            bool tapsAreCloseInTime = ((e.Timestamp - _lastTimestamp) < 700);
            if (tapsAreCloseInTime && tapsAreCloseInDistance)
            {
                _lastTapLocation = null;
            }
            return tapsAreCloseInDistance && tapsAreCloseInTime;
        }
    }
