    public static class WindowStateManager
    {
        public static WindowState _state;
        private static double _height;
        private static double _width;
        private static double _left;
        private static double _top;
        public static void SetState(this Window window)
        {
            _state = window.WindowState;
            _height = window.Height;
            _width = window.Width;
            _left = window.Left;
            _top = window.Top;
        }
        public static void ApplyState(this Window window)
        {
            window.WindowState = _state;
            window.Height = _height;
            window.Width = _width;
            window.Left = _left;
            window.Top = _top;
        }
    }
