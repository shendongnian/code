    using System;
    using System.Diagnostics;
    using System.Threading;
    namespace ConsoleApplication1
    {
        class Program
        {
            static bool running, exit;
            static int burst;
            static long guidCount = 0;
            static long[] counts = new long[256];
            static DateTime nextReport = DateTime.MinValue;
            static readonly TimeSpan reportInterval = TimeSpan.FromSeconds(1);
            static void Main(string[] args)
            {
                Console.WindowHeight = (int)(0.8 * Console.LargestWindowHeight);
                WriteLine(ConsoleColor.White, "X - Exit | P - Run/Pause | S - Step (hold for Slow) | B - Burst");
                WriteLine("Press P, S or B to make something happen.", reportInterval);
                Guid guid;
                byte[] bytes;
                var cursorPos = new CursorLocation();
                while (!exit)
                {
                    if (Console.KeyAvailable)
                    {
                        ProcessKey(Console.ReadKey(true));
                    }
                    if (running || burst > 0)
                    {
                        guid = Guid.NewGuid();
                        bytes = guid.ToByteArray();
                        ++guidCount;
                        for (int i = 0; i < 16; i++)
                        {
                            var b = bytes[i];
                            ++counts[b];
                        }
                        if (burst > 0) --burst;
                        if (burst == 0 && DateTime.Now > nextReport)
                        {
                            cursorPos.MoveCursor();
                            ReportFrequencies();
                        }
                    }
                    else
                        Thread.Sleep(20);
                }
            }
            static void ProcessKey(ConsoleKeyInfo keyInfo)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.P:
                        running = !running;
                        break;
                    case ConsoleKey.B:
                        burst = 100;
                        break;
                    case ConsoleKey.S:
                        burst = 1;
                        break;
                    case ConsoleKey.X:
                        exit = true;
                        break;
                }
            }
            static void ReportFrequencies()
            {
                Write("\r\n{0} GUIDs generated. Frequencies (%):\r\n\r\n", guidCount);
                const int itemWidth = 11;
                const int colCount = 8; // Console.WindowWidth / (itemWidth + 2);
                for (int i = 0; i < 256; i++)
                {
                    var f = (double)counts[i] / (16 * guidCount);
                    var c = GetFrequencyColor(f);
                    Write(c, RightAdjust(3, "{0:x}", i));
                    Write(c, " {0:0.00}".PadRight(itemWidth), f*100);
                    if ((i + 1) % colCount == 0) Write("\r\n");
                }
                nextReport = DateTime.Now + reportInterval;
            }
            static ConsoleColor GetFrequencyColor(double f)
            {
                if (f < 0.003) return ConsoleColor.DarkRed;
                if (f < 0.004) return ConsoleColor.Green;
                if (f < 0.005) return ConsoleColor.Yellow;
                return ConsoleColor.White;
            }
            static string RightAdjust(int w, string s, params object[] args)
            {
                if (args.Length > 0)
                    s = string.Format(s, args);
                return s.PadLeft(w);
            }
            #region From my library, so I need not include that here...
            class CursorLocation
            {
                public int X, Y;
                public CursorLocation()
                {
                    X = Console.CursorLeft;
                    Y = Console.CursorTop;
                }
                public void MoveCursor()
                {
                    Console.CursorLeft = X;
                    Console.CursorTop = Y;
                }
            }
            static public void Write(string s, params object[] args)
            {
                if (args.Length > 0) s = string.Format(s, args);
                Console.Write(s);
            }
            static public void Write(ConsoleColor c, string s, params object[] args)
            {
                var old = Console.ForegroundColor;
                Console.ForegroundColor = c;
                Write(s, args);
                Console.ForegroundColor = old;
            }
            static public void WriteNewline(int count = 1)
            {
                while (count-- > 0) Console.WriteLine();
            }
            static public void WriteLine(string s, params object[] args)
            {
                Write(s, args);
                Console.Write(Environment.NewLine);
            }
            static public void WriteLine(ConsoleColor c, string s, params object[] args)
            {
                Write(c, s, args);
                Console.Write(Environment.NewLine);
            }
            #endregion
        }
    }
