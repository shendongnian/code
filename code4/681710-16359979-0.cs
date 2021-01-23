    for (int i = 0; i < input.Length; i++)
    {
        for (int j = 0; j < separators.Length; j++)
        {
            if (input[i] == separators[j])
                Console.WriteLine((i + 1) + "\"" + separators[j] + "\"");
        }
    }
