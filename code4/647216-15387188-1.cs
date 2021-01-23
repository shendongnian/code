    using System;
    using System.IO;
    namespace Demo
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                // This does NOT cause any exceptions:
                using (Stream stream = new FileStream("c:\\test\\file.txt", FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write("TEST");
                    }
                }
            }
        }
    }
                        
