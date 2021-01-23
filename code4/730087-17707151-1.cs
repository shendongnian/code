    public interface IParseResult {
      // whether the operation succeeded
      bool Success { get; }
      // contains error messages, can also be a single string message
      IEnumerable<string> Messages { get; } 
      // the result of the operation in case of success, null otherwise
      MyClass MyClass { get; }
    }
