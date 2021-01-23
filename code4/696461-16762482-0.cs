        class TextFileReader
        {
            static void Main(string[] args)
            {
                string path = @"player\mp-config.cfg";
                string readText = File.ReadAllText(path);
                string secondWord = readText.Split()[1];
                int value = Int32.Parse(secondWord);
                if (value == 0)
                {
                    Console.WriteLine("Sorry but have to use full Screen mod.");
                    using (StreamWriter outfile = new StreamWriter(path))
                    {
                        outfile.Write("r_val 1");
                    }
                }
            }
        }
