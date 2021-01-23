    namespace Hangman
        {
            class Program
            {
                static string word = string.Empty;
                static string label = string.Empty;
                static int tries = 0;
                static string misses = string.Empty;
        
                static void Main(string[] args)
                {
                    word = args[0];
        
                    label = new Regex(" ").Replace(word, "/");
                    label = new Regex("([a-zA-z0-9])").Replace(label, "_");
        
                    ProcessKeyStroke();
        
                    Console.Read();
                }
        
        
                static void ProcessKeyStroke()
                {
                    // Write the latest game information
                    Console.Clear();
                    Console.WriteLine("Tries remaining: {0}", 9 - tries);
                    Console.WriteLine(label);
                    Console.WriteLine("Misses: {0}", misses);
        
                    // Check if the player won
                    if (!label.Contains("_"))
                    {
                        Console.WriteLine("You won!");
                        return;
                    }
        
                    // Check if the player lost
                    if (tries == 9)
                    {
                        Console.WriteLine("You lost!\n\nThe word was: {0}", word);
                    }
        
                    // Process the key stroke
                    char gameLetter = Console.ReadKey().KeyChar;
                    bool MatchFound = false;
        
                    int Index = 0;
                    foreach (char currentLetter in word.ToLower())
                    {
                        if (currentLetter == gameLetter)
                        {
                            MatchFound = true;
        
                            label = label.Remove(Index, 1);
                            label = label.Insert(Index, gameLetter.ToString());
                        }
                        Index++;
                    }
        
                    // Add the miss if the playe rmissed
                    if (!MatchFound)
                    {
                        tries++;
                        misses += gameLetter + ", ";
                    }
        
                    // Recurse
                    ProcessKeyStroke();
                }
            }
        }
