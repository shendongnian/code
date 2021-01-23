    IEnumerable<string> GenerateCode(int length, int min, IEnumerable<char> chars)
    {
        if (length == 0)
        {
            yield return string.Empty;
            yield break;
        }
        foreach (var mid in GenerateCode(length - 1, min, chars))
        {
            foreach (var c in chars)
            {
                var t = mid + c;
                if (length >= min)
                    Console.WriteLine(t); // replace with where you want to put the results
                yield return t;
            }
        }
    }
    // now call this method:
    GenerateCode(3 /*max length*/, 2 /*min length*/, new [] { 'a', 'b', 'c'  });
