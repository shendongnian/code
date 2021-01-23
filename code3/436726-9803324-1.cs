                List<string> dictionaryList = new List<string>();
                
                string input;
    
                Console.Write("Please enter a string or END to finish: ");
                input = Console.ReadLine();
                while (input.ToUpper() != "END")
                {
                    if (dictionaryList.Contains(input))
                    {
                        Console.Write("Do you want to have dup string(Y/N):");
                        string response = string.Empty;
                        response = Console.ReadLine();
                        if (response.ToUpper().Equals("Y"))
                            dictionaryList.Add(input);    
                    }
                    else
                    {
                        dictionaryList.Add(input);
                    }
                    Console.Write("Please enter a string or END to finish: ");
                    input = Console.ReadLine();
    
                }
    
                dictionaryList.Sort();
                Console.WriteLine("Dictionary Contents:");
                foreach (string wordList in dictionaryList)
                    Console.WriteLine("\t" + wordList);
