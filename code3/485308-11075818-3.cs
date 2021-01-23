    string str = Console.ReadLine();
    string low_str = str.ToLower();
    Console.Clear();
    Console.WriteLine("Thank you.  The sentence you entered was: \n\"{0}\"", str);
    Console.WriteLine("This sentence is {0} characters long.", str.Length);
    
    int vowelCount = 0;
    int eCount = 0;
    
    for (int i = 0; i < low_str.Length; i++)
    {
        switch(low_str[i])
        {
            case 'e': eCount ++; vowelCount++; break;
            case 'a': vowelCount++; break;
            case 'o': vowelCount++; break;
            case 'i': vowelCount++; break;
            case 'u': vowelCount++; break;
            case 'y': vowelCount++; break;
        }
    }
    
    Console.WriteLine("It contains {0} instances of the letter \'e\'.", eCount);
    Console.WriteLine("There are {0} vowels used.", vowelCount);
    Console.ReadLine();
