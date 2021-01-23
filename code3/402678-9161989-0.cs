    internal interface ISomeInterface  
    {
      /// <summary>
      /// Integer1 help text by interface.
      /// </summary>
      int Integer1 { get; set; }
    }
    internal class Class2 : ISomeInterface
    {
      public int Integer1 { get; set; }
      public int CallInterface1( )
      {
        return Integer1; // <- Place cursor on Integer1 and press Ctrl+Shift+F1
      }
    }
