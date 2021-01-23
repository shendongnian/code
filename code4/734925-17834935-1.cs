    string resultword=word;
        do
                {
                    char guess = char.Parse(Console.ReadLine());
                    
                   
                    if (word.Contains(guess))
                    {
                        resultword=resultword.Replace(guess,' ');
                        foreach (char item in word)
                        {
        
                            if (item == guess)
                            {
                                Console.Write(item);
                            }
                            else
                            {
                                Console.Write("_");
                            }
        
                        }
                    }
        
                  Console.WriteLine();
                } 
                //If my word contains A "_" i will keep looping
                while (tries-->0 && resultword.Trim()!=string.Empty);
