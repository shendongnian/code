    public struct ExampleStruct
    {
      readonly int valueMinusOne;
      public int Value { get { return valueMinusOne + 1; } }
      public ExampleStruct(int value)
      {
        valueMinusOne = value - 1;
      }
    }
