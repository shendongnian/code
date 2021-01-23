    class Program
    {
        public class SearchData
        {
            public string ClassName { get; set; }
            public string Title { get; set; }
            private readonly List<IntPtr> _result = new List<IntPtr>();
            public List<IntPtr> Result
            {
                get { return _result; }
            }
        }
        
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, ref SearchData data);
        private delegate bool EnumWindowsProc(IntPtr hWnd, ref SearchData data);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        public static bool EnumProc(IntPtr hWnd, ref SearchData searchData)
        {
            var sbClassName = new StringBuilder(1024);
            GetClassName(hWnd, sbClassName, sbClassName.Capacity);
            if (searchData.ClassName == null || Regex.IsMatch(sbClassName.ToString(), searchData.ClassName))
            {
                var sbWindowText = new StringBuilder(1024);
                GetWindowText(hWnd, sbWindowText, sbWindowText.Capacity);
                if (searchData.Title == null || Regex.IsMatch(sbWindowText.ToString(), searchData.Title))
                {
                    searchData.Result.Add(hWnd);
                }
            }
            return true;
        }
        
        static void Main(string[] args)
        {
            var searchData = new SearchData 
                { 
                    ClassName = "AcrobatSDIWindow", 
                    Title = "^My Document\\.pdf.*"
                };
            EnumWindows(EnumProc, ref searchData);
            var firstResult = searchData.Result.FirstOrDefault();
            if (firstResult != IntPtr.Zero)
            {
                SetForegroundWindow(firstResult);
            }
        }
    }
