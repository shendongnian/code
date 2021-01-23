    foreach (var example in wordExamples)
    {
        Console.WriteLine("Word {0}", example.Key);
        foreach (var sentence in example)
        {
            // I assume you've really got the full sentence here...
            Console.WriteLine("  {0}", string.Join(" ", sentence.Words));
        }
    }
