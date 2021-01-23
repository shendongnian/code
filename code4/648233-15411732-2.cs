    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Runtime.Versioning;
    
    namespace Test
    {
        internal class Program
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, EntryPoint = "lstrlenA")]
            [ResourceExposure(ResourceScope.None)]
            internal static extern int lstrlenA(IntPtr ptr);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            private static extern System.IntPtr GetCommandLine();
    
            private static readonly IntPtr HIWORDMASK = unchecked(new IntPtr((long)0xffffffffffff0000L));
    
            private static bool IsWin32Atom(IntPtr ptr)
            {
                long num = (long)ptr;
                return 0 == (num & (long)HIWORDMASK);
            }
    
            public static string PtrToString(IntPtr p)
            {
                if (p == IntPtr.Zero)
                    return null;
                if (IsWin32Atom(p))
                    return null;
                int len = lstrlenA(p);
                if (len == 0)
                    return String.Empty;
                return Marshal.PtrToStringAnsi(p, len);
            }
    
            private static void Main(string[] args)
            {
                var p = Marshal.StringToHGlobalAnsi("Console.WriteLine(\"Marshal class: result={0} time={1}ms\", s, sw.ElapsedMilliseconds);");
    
                string s = "";
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (double i = 0; i < 5000000; i++)
                {
                    s = Marshal.PtrToStringAnsi(p);
                }
                sw.Stop();
                Console.WriteLine("Marshal class: result={0} time={1}ms", s, sw.ElapsedMilliseconds);
                sw.Restart();
                for (double i = 0; i < 5000000; i++)
                {
                    s = Program.PtrToString(p);
                }
                sw.Stop();
                Console.WriteLine("My implementation: result={0} time={1}ms", s, sw.ElapsedMilliseconds);
                Console.ReadLine();
            }
        }
    }
