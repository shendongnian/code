            static void Main(string[] args)
            {
    
                Console.WriteLine("****please enter path to your file****");
                Console.Write("Path: ");
                string pth = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Your file content is:");
                using (StreamReader sr = File.OpenText(pth))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
    
                Console.ReadKey();
            }
