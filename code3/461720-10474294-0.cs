    using System;
    using ICSharpCode.SharpZipLib.BZip2;
    using System.IO;
    
    namespace Test
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                var fStream = new FileStream("/home/konrad/output.bin", FileMode.Create);
                using(var writer = new StreamWriter(new BZip2OutputStream(fStream)))
                {
                    for(var i = 0; i < 10; i++)
                    {
                        writer.WriteLine("Line no {0}.", i);
                    }
                }
            }
        }
    
    }
