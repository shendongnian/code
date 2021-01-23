            static void Main(string[] args)
            {
                string fileName = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Yourfile.txt");
         
                Console.WriteLine("Your file content is:");
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
    
                Console.ReadKey();
            }
