    static void Main()
            {
                var words = new List<string> { "abcd", "wxyz", "1234"};
    
                foreach (var character in SplitItOut(words))
                {
                    Console.WriteLine(character);
                }
            }
    
    
            static char[] GetCharacters(string word)
            {
                Thread.Sleep(5000);
                return word.ToCharArray();
            }
