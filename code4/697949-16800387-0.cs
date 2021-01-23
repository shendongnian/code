    public static class WindowManager
    {
        public static event EventHandler<EventArgs> ClosingWindows;
        
        public static void CloseWindows()
        {
            var c = ClosingWindows;
            if (c != null)
            {
                c(null, EventArgs.Empty);
            }
        }
    }
