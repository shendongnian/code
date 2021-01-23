    using System;
    using System.Diagnostics;
    using System.Runtime;
    
    namespace demo
    {
        class MainClass
        {
            static bool ByForArrayLength (byte[] data)
            {
                for (int i = 0; i < data.Length; i++)
                    if (data [i] != 0)
                        return false;
                return true;
            }
    
            static bool ByForLocalLength (byte[] data)
            {
                int len = data.Length;
                for (int i = 0; i < len; i++)
                    if (data [i] != 0)
                        return false;
                return true;
            }
    
            static unsafe bool ByForUnsafe (byte[] data)
            {
                fixed (byte* datap = data)
                {
                    int len = data.Length;
                    for (int i = 0; i < len; i++)
                        if (datap [i] != 0)
                            return false;
                    return true;
                }
            }
    
            static bool ByForeach (byte[] data)
            {
                foreach (byte b in data)
                    if (b != 0)
                        return false;
                return true;
            }
    
            static void Measure (Action work, string description)
            {
                GCSettings.LatencyMode = GCLatencyMode.LowLatency;
                var watch = Stopwatch.StartNew ();
                work.Invoke ();
                Console.WriteLine ("{0,-40}: {1} ms", description, watch.Elapsed.TotalMilliseconds);
            }
    
            public static void Main (string[] args)
            {
                byte[] data = new byte[256 * 1024 * 1024];
                Measure (() => ByForArrayLength (data), "For with .Length property");
                Measure (() => ByForLocalLength (data), "For with local variable");
                Measure (() => ByForUnsafe (data), "For with local variable and GC-pinning");
                Measure (() => ByForeach (data), "Foreach loop");
            }
        }
    }
