        string displayword = String.Copy(word);
        for (int j = 0; j < displayword.length; j++) displayword[j]='_';
        do {
            // Display the word so far.
            Console.WriteLine("Word is {0}", displayword);
            // Get a guess from the user
            char guess = char.Parse(Console.ReadLine());
            if (word.Contains(guess)) {
                displayword.Replace('_', guess);
            } else {
              // Decrease the tries.
              tries--;
            }
        } while (displayword.Contains("_") && (tries > 0));
