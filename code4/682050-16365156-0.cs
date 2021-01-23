    using System;
    using System.Runtime.InteropServices;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    using (new Test())
                    {
                        // All is well.
                    }
                    using (new Test())
                    {
                        throw new InvalidOperationException("Eeep");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception detected: " + ex.Message);
                }
            }
        }
        sealed class Test: IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine(
                    Marshal.GetExceptionPointers() == IntPtr.Zero
                    ? "Disposing test normally."
                    : "Disposing test because of an exception.");
            }
        }
    }
