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
                        String line = sr.ReadToEnd();
                        string[] array = line.Split(':');                    
                        Console.WriteLine(array[1]);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
        }
