    public static class MouseButtonHelper
    {
        private const long k_DoubleClickSpeed = 500;
        private const double k_MaxMoveDistance = 10;
        private static long _LastClickTicks = 0;
        private static System.Windows.Point _LastPosition;
        private static WeakReference _LastSender;
        private static System.Windows.Point _DragStartPosition;
        public static bool IsDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Point position = e.GetPosition(null);
            long clickTicks = DateTime.Now.Ticks;
            long elapsedTicks = clickTicks - _LastClickTicks;
            long elapsedTime = elapsedTicks / TimeSpan.TicksPerMillisecond;
            bool quickClick = (elapsedTime <= k_DoubleClickSpeed);
            bool senderMatch = (_LastSender != null && sender.Equals(_LastSender.Target));
            if (senderMatch && quickClick && position.Distance(_LastPosition) <= k_MaxMoveDistance)
            {
                // Double click!
                _LastClickTicks = 0;
                _LastSender = null;
                return true;
            }
            // Not a double click
            _LastClickTicks = clickTicks;
            _LastPosition = position;
            if (!quickClick)
                _LastSender = new WeakReference(sender);
            return false;
        }
        public static void setStartPosition(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _DragStartPosition = e.GetPosition(null);
        }
        public static bool IsDragging(object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Windows.Point mousePos = e.GetPosition(null);
            System.Windows.Vector diff = _DragStartPosition - mousePos;
            if (Math.Abs(diff.X) > System.Windows.SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > System.Windows.SystemParameters.MinimumVerticalDragDistance)
            {
                return true;
            }
            return false;
        }
        private static double Distance(this System.Windows.Point pointA, System.Windows.Point pointB)
        {
            double x = pointA.X - pointB.X;
            double y = pointA.Y - pointB.Y;
            return Math.Sqrt(x * x + y * y);
        }
    }
