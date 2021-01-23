    [Flags]
    public enum Symbol {
      FirstA = 1,
      FirstB = 2,
      SecondA = 4,
      SecondB = 8
    }
    
    public enum Production {
      AA = Symbol.FirstA | Symbol.SecondA,
      AB = Symbol.FirstA | Symbol.SecondB,
      BA = Symbol.FirstB | Symbol.SecondA
    }
