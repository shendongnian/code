    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.IO;
    
    class Program {
        static void Main(string[] args) {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            path = Path.Combine(path, "symbols");
            Environment.SetEnvironmentVariable("_NT_SYMBOL_PATH", path);
            try {
                Kaboom();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void Kaboom() {
            throw new Exception("test");
        }
    }
