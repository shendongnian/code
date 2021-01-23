    /// <summary>
    /// Returns a sequence of window handles (IntPtrs) for all top-level windows
    /// matching the specfied window class name.
    /// </summary>
    /// <param name="className">The windows class name to match (not to be confused with a C# class name!)</param>
    /// <returns>A non-null sequence of window handles. This will be an empty sequence if no windows match the class name.</returns>
    public static IEnumerable<IntPtr> WindowsMatchingClassName(string className)
    {
        if (string.IsNullOrWhiteSpace(className))
        {
            throw new ArgumentOutOfRangeException("className", className, "className can't be null or blank.");
        }
        return WindowsByClassFinder.WindowsMatching(className);
    }
    /// <summary>Finds windows matching a particular window class name.</summary>
    private class WindowsByClassFinder
    {
        /// <summary>Find the windows matching the specified class name.</summary>
        public static IEnumerable<IntPtr> WindowsMatching(string className)
        {
            return new WindowsByClassFinder(className)._result;
        }
        private WindowsByClassFinder(string className)
        {
            _className = className;
            EnumWindows(callback, IntPtr.Zero);
        }
        private bool callback(IntPtr hWnd, IntPtr lparam)
        {
            if (GetClassName(hWnd, _apiResult, _apiResult.Capacity) != 0)
            {
                if (string.CompareOrdinal(_apiResult.ToString(), _className) == 0)
                {
                    _result.Add(hWnd);
                }
            }
            return true; // Keep enumerating.
        }
        [SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage"), SuppressUnmanagedCodeSecurity]
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool EnumWindows(EnumWindowsDelegate lpEnumFunc, IntPtr lparam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        private delegate bool EnumWindowsDelegate(IntPtr hWnd, IntPtr lparam);
        private readonly string _className;
        private readonly List<IntPtr> _result = new List<IntPtr>();
        private readonly StringBuilder _apiResult = new StringBuilder(1024);
    }
