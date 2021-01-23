    public static void Main(string[] args)
        {
            int vowelsInString = 0;
            int consonants = 0;
            int lengthOfString;
            char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };
            string ourString;
            Console.WriteLine("Enter a sentence or a word");
            ourString = Console.ReadLine();
            ourString = ourString.ToLower();
            foreach (char character in ourString)
            {
                for (int i = 0; i < vowels.Length; i++)
                {
                    if (vowels[i] == character) 
                    {
                        vowelsInString++;
                    }
                }
            }
            lengthOfString = ourString.Count(c => !char.IsWhiteSpace(c)); //gets the length of the string without any whitespaces
            consonants = lengthOfString - vowelsInString; //Well, you get the idea.
            Console.WriteLine();
            Console.WriteLine("Vowels in our string: " + vowelsInString);
            Console.WriteLine("Consonants in our string " + consonants);
            Console.ReadKey();
        }
    }
