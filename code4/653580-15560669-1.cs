    string searchItem = "Error 500";
    
                var lines = File.ReadLines("c:/temp/ESMDLOG.csv");
    
                    foreach (string line in lines)
                    {
                        if (line.Contains(searchItem))
                        {
                            Console.WriteLine(line);
                        }
    
                    }
