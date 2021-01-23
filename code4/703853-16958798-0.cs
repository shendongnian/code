    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;
    namespace Demo
    {
        class WindowsByClassFinder
        {
            /// <summary>See the Windows API SDK Help for details.</summary>
            public delegate bool EnumWindowsDelegate(IntPtr hWnd, IntPtr lparam);
            [SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage"), SuppressUnmanagedCodeSecurity]
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
            /// <summary>See the Windows API SDK Help for details.</summary>
            [SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage"), SuppressUnmanagedCodeSecurity]
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public extern static bool EnumWindows(EnumWindowsDelegate lpEnumFunc, IntPtr lparam);
            /// <summary>See the Windows API SDK Help for details.</summary>
            [SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage"), SuppressUnmanagedCodeSecurity]
            [DllImport("User32", CharSet=CharSet.Auto, SetLastError=true)]
            public static extern int GetWindowText(IntPtr windowHandle, StringBuilder stringBuilder, int nMaxCount);
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
            public static IEnumerable<string> WindowTitlesForClass(string className)
            {
                var sb = new StringBuilder();
                foreach (var windowHandle in WindowsMatchingClassName(className))
                {
                    if (windowHandle != IntPtr.Zero)
                    {
                        sb.Clear();
                        GetWindowText(windowHandle, sb, 8192);
                        yield return sb.ToString();
                    }
                }
            }
            public static IEnumerable<IntPtr> WindowsMatchingClassName(string className)
            {
                if (string.IsNullOrWhiteSpace(className))
                    throw new ArgumentOutOfRangeException("className", className, "className can't be null or blank.");
                return WindowsMatching(className);
            }
            private readonly string _className;
            private readonly List<IntPtr> _result = new List<IntPtr>();
            private readonly StringBuilder _apiResult = new StringBuilder(1024);
        }
        class Program
        {
            void run()
            {
                ChromeWindowTitles().Print();
            }
            public IEnumerable<string> ChromeWindowTitles()
            {
                foreach (var title in WindowsByClassFinder.WindowTitlesForClass("Chrome_WidgetWin_0"))
                    if (!string.IsNullOrWhiteSpace(title))
                        yield return title;
                foreach (var title in WindowsByClassFinder.WindowTitlesForClass("Chrome_WidgetWin_1"))
                    if (!string.IsNullOrWhiteSpace(title))
                        yield return title;
            }
            static void Main()
            {
                new Program().run();
            }
        }
        static class DemoUtil
        {
            public static void Print(this object self)
            {
                Console.WriteLine(self);
            }
            public static void Print(this string self)
            {
                Console.WriteLine(self);
            }
            public static void Print<T>(this IEnumerable<T> self)
            {
                foreach (var item in self)
                    Console.WriteLine(item);
            }
        }
    }
