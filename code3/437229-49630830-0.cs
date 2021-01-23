    public static class WindowExtensions
    {
        /// <summary>
        /// Gets the window left.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns></returns>
        public static double GetWindowLeft(this Window window)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                var leftField = typeof(Window).GetField("_actualLeft", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                return (double)leftField.GetValue(window);
            }
            else
                return window.Left;
        }
        /// <summary>
        /// Gets the window top.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns></returns>
        public static double GetWindowTop(this Window window)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                var topField = typeof(Window).GetField("_actualTop", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                return (double)topField.GetValue(window);
            }
            else
                return window.Top;
        }
    }
