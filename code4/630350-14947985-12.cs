    static void Main(string[] args)
    {
      const string expectedResult = "This Is A Test";
      var samples = new string[][]
          {
            new [] {"This Is A Test", "This Is A Test"},
            new [] {"ThisIsATest", "This Is A Test"},
            new [] {"This_Is_A_Test", "This Is A Test"},
            new [] {"ThisIsA_Test", "This Is A Test"},
            new [] {"This_IsATest", "This Is A Test"},
            new [] {"_ThisIsATest", "This Is A Test"},
            new [] {"_This_Is_A_Test", "This Is A Test"},
            new [] {"Thi_s_Is_A_Test", "Thi s Is A Test"},
            new [] {"T hi_s_Is_A_Te s_ t", "T hi s Is A Te s  t"}
          };
      foreach (var input in samples)
      {
        Console.WriteLine(input[0] + " => " + input[1]);
        // Guffa 1 1/9 correct.
        Console.WriteLine("Guffa 1:         " + (Regex.Replace(input[0], @"([a-z])_?([A-Z])", "$1 $2") == input[1]));
        // Guffa 2 4/9 correct.
        Console.WriteLine("Guffa 2:         " + (Regex.Replace(input[0], @"(?<!^)_?([A-Z])", " $1") == input[1]));
        // Abe Miesler 1/9 correct.
        Console.WriteLine("Abe Miesler:     " + (Regex.Replace(input[0], @"([a-zA-Z])_?([A-Z])", "$1 $2") == input[1]));
        // AppDeveloper 2/9 correct. (Not entirely fair since it was not meant for underscores).
        Console.WriteLine("AppDeveloper:    " + (Regex.Replace(input[0], @"_([A-Z])", " $1") == input[1]));
        // sparky68967 1/9 correct. (Not entirely fair since it was not meant for underscores).
        Console.WriteLine("sparky68967:     " + (Regex.Replace(input[0], @"([a-z])([A-Z])", "$1 $2") == input[1]));
        // p.s.w.g 4/9 correct.
        Console.WriteLine("p.s.w.g:         " + (Regex.Replace(Regex.Replace(input[0], @"([A-Z]+)([A-Z][a-z])", "$1_$2"), "_", " ") == input[1]));
        // Sani Huttunen 1 7/9 correct.
        Console.WriteLine("Sani Huttunen 1: " + (Regex.Replace(input[0], @"([a-z]?)[_ ]?([A-Z])", "$1 $2").TrimStart(' ') == input[1]));
        // Sani Huttunen 2 9/9 correct.
        Console.WriteLine("Sani Huttunen 2: " + (Regex.Replace(input[0].Replace('_', ' '), @"(?<!^)[ ]?([A-Z])", " $1").TrimStart(' ') == input[1]));
        Console.WriteLine();
      }
    }
