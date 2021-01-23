    using System;
    using System.IO;
    
    class Test
    {
        public static void Main()
        {
                try
                {
                    using (StreamReader sr = new StreamReader("TestFile.txt"))
                    {
                        while (!sr.EndOfStream)
                        {
                            String line = sr.ReadLine();
                            if (line != null && line.Contains(":"))
                                Console.WriteLine(line.Split(':')[1]);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
        }
    }
