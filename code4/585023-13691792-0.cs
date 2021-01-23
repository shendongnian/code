    static string FindShortestSubstringPeriod(string input)
    {
      if (string.IsNullOrEmpty(input))
        return input;
      for (int length = 1; length <= input.Length / 2; ++length)
      {
        int remainder;
        int repetitions = Math.DivRem(input.Length, length, out remainder);        
        if (remainder != 0)
          continue;
        string candidate = input.Remove(length);
        if (String.Concat(Enumerable.Repeat(candidate, repetitions)) == input)
          return candidate;
      }
      return input;
    }
