    while (word.Contains("_"))
    {
            char guess = char.Parse(Console.ReadLine());
            currentLetters.Add(guess);
            foreach (var l in word.ToCharArray().Intersect(currentLetters).ToArray())
            {
                word = word.Replace(l, '_');
            }
    }
