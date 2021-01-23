    string resultword = word;
    do
    {
        char guess = char.Parse(Console.ReadLine());
    
    
        if (word.Contains(guess))
        {
            resultword = resultword.Replace(guess, ' ');
    
            for (int i = 0; i < resultword.Count(); i++)
            {
                if (resultword[i] == ' ')
                {
                    Console.Write(word[i]);
                }
                else
                {
                    Console.Write("_");
                }
            }
        }
    
        Console.WriteLine();
    }
    while (tries-- != 0 && resultword.Trim() != string.Empty);
