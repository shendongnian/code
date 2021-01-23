    char[] inputChars = Console.ReadLine().ToCharArray();
    int vowels = 0;
    int consonants = 0;
    foreach (char c in inputChars)
    {
       if ("aeiou".Contains(c) || "AEIOU".Contains(c))
       {
           vowels++;
       }
       else
       {
           consonants++;
       }
    }
    Console.WriteLine("Vowel count: {0} - Consonant count: {1}", vowels, consonants);
    Console.ReadKey();
