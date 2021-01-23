    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Reflection;
    namespace TryGitDescribe
    {
        class Program
        {
            static void Main(string[] args)
            {
                string gitVersion= String.Empty;
                using (Stream stream = Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream("TryGitDescribe." + "version.txt"))
                using (StreamReader reader = new StreamReader(stream))
                {
                    gitVersion= reader.ReadToEnd();
                }
                Console.WriteLine("Version: {0}", gitVersion);
                Console.WriteLine("Hit any key to continue");
                Console.ReadKey();
            }
        }
    }
