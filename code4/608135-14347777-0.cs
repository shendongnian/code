        static void Main(string[] args) {
        string input = "a29z3";
        string output = string.Empty;
        foreach (char letter in input.ToCharArray()) {
            output += replacementChar(letter);
        }
                  
        Console.WriteLine(output);
    
        }
        static char replacementChar(char c) {
            switch (c) {
                case 'a': return 'z'; 
                case 'b': return 'y'; 
                // and so on
                default: return c;
            }
        }
