    static void Main(string[] args)
            {
    
                try
                {
                    System.IO.TextReader readFile = new StreamReader(@"C:\Temp\test.txt");
                    int count = 0;
                    List<string> lines= new List<string>();
                    foreach (string line in ReadLineFromFile(readFile))
                    {
                        if (count == 10)
                        {
                            count = 0;
                            ProcessChunk(lines);
                            lines.Add(line);
                        }
                        else
                        {
                            lines.Add(line);
                            count++;
                        }
                        
                    }
                    //PROCESS the LINES
                    ProcessChunk(lines);
    
                    Console.ReadKey();
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
    
            private static void ProcessChunk(List<string> lines)
            {
                Console.WriteLine("----------------");
                lines.ForEach(l => Console.WriteLine(l));
                lines.clear();
            }
    
            private static IEnumerable<string> ReadLineFromFile(TextReader fileReader)
            {
                using (fileReader)
                {
                    string currentLine;
                    while ((currentLine = fileReader.ReadLine()) != null)
                    {
                        yield return currentLine;
                    }
                }
            }
