    class Options {
      [Option("a", null, MutuallyExclusiveSet="zero")] 
      public string OptionA { get; set; }
      [Option("b", null, MutuallyExclusiveSet="zero")] 
      public string OptionB { get; set; }
      [Option("c", null, MutuallyExclusiveSet="one")] 
      public string OptionC { get; set; }
      [Option("d", null, MutuallyExclusiveSet="one")] 
      public string OptionD { get; set; }
    }
