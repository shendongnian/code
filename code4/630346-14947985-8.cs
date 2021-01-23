    const string expectedResult = "This Is A Test";
    var samples = new[]
                  {
                    "This Is A Test",
                    "ThisIsATest",
                    "This_Is_A_Test",
                    "ThisIsA_Test",
                    "This_IsATest",
                    "_ThisIsATest"
                  };
    foreach (var input in samples)
    {
      Console.WriteLine(input);
      
      // Guffa 1/6 correct.
      Console.WriteLine("Guffa:         " + (Regex.Replace(input, @"([a-z])_?([A-Z])", "$1 $2") == expectedResult));
      // Abe Miesler 1/6 correct.
      Console.WriteLine("Abe Miesler:   " + (Regex.Replace(input, @"([a-zA-Z])_?([A-Z])", "$1 $2") == expectedResult));
      // AppDeveloper 2/6 correct. (Not entirely fair since it was not meant for underscores).
      Console.WriteLine("AppDeveloper:  " + (Regex.Replace(input, @"_([A-Z])", " $1") == expectedResult));
      // sparky68967 1/6 correct. (Not entirely fair since it was not meant for underscores).
      Console.WriteLine("sparky68967:   " + (Regex.Replace(input, @"([a-z])([A-Z])", "$1 $2") == expectedResult));
      // p.s.w.g 2/6 correct.
      Console.WriteLine("p.s.w.g:       " + (Regex.Replace(Regex.Replace(input, @"([A-Z]+)([A-Z][a-z])", "$1_$2"), "_", " ") == expectedResult));
      // Sani Huttunen 6/6 correct.
      Console.WriteLine("Sani Huttunen: " + (Regex.Replace(input, @"([a-z]?)[_^ ]?([A-Z])", "$1 $2").TrimStart(' ') == expectedResult));
      Console.WriteLine();
    }
