    char[] inputChars = Console.ReadLine().ToCharArray();
    int vowels = 0;
    foreach (char c in inputChars)
    {
       if ("aeiou".Contains(c) || "AEIOU".Contains(c))
       {
           vowels++;
       }
    }
    Console.WriteLine("Vowel count: {0}", vowels);
    Console.ReadKey();
