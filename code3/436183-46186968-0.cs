    string test = "Malayalam";
                char[] palindrome = test.ToCharArray();
                char[] reversestring = new char[palindrome.Count()];
                for (int i = palindrome.Count() - 1; i >= 0; i--)
                {
                    reversestring[palindrome.Count() - 1 - i] = palindrome[i];
    
                }
    
                string materializedString = new string(reversestring);
    
                if (materializedString.ToLower() == test.ToLower())
                {
                    Console.Write("Palindrome!");
                }
                else
                {
                    Console.Write("Not a Palindrome!");
                }
    
                Console.Read();
