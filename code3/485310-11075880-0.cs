    Char[] vowels = {'e', 'a', 'o', 'i', 'u', 'y'};
    string str = Console.ReadLine();
    string low_str = str.ToLower();
    Console.Clear();
    Console.WriteLine("Thank you.  The sentence you entered was: \n\"{0}\"", str);
    Console.WriteLine("This sentence is {0} characters long.", str.Length);
    
    int vowelCount = 0;
    int eCount = 0;
    
    foreach (char chara in low_str)
    {
        foreach (char vowel in vowels)
        if (vowel == chara)
            vowelCount++;
        if (chara == 'e')
            eCount++;
    }
    
    Console.WriteLine("It contains {0} instances of the letter \'e\'.", eCount);
    Console.WriteLine("There are {0} vowels used.", vowelCount);
    Console.ReadLine();
