    static void Main(string[] args)
            {
                string text = "C# is the best language there is in the world.";
                string search = "the";
                Match match = Regex.Match(text, search);
                Console.WriteLine("there was {0} matches for '{1}'", match.Groups.Count, match.Value);
                Console.ReadLine();
            }
