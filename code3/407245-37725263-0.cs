        public static class ext
    {
    private static Point? _lastTapLocation;
            private static readonly Stopwatch _DoubleTapStopwatch = new Stopwatch();
            public static bool IsDoubleTap(this StylusSystemGestureEventArgs e, IInputElement iInputElement)
            {
                Point currentTapPosition = e.GetPosition(iInputElement);
                bool tapsAreCloseInDistance = false;
                if (_lastTapLocation != null)
                {
                    tapsAreCloseInDistance = GetDistanceBetweenPoints(currentTapPosition, (Point)_lastTapLocation) < 70;
                }
                _lastTapLocation = currentTapPosition;
    
                TimeSpan elapsed = _DoubleTapStopwatch.Elapsed;
                _DoubleTapStopwatch.Restart();
                bool tapsAreCloseInTime = (elapsed != TimeSpan.Zero && elapsed < TimeSpan.FromSeconds(0.7));
    
                if (tapsAreCloseInTime && tapsAreCloseInDistance)
                {
                    _lastTapLocation = null;
                }
                return tapsAreCloseInDistance && tapsAreCloseInTime;
            }
    }
