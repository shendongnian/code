    class MyClass
    {
        private Func<string, int> _valueConverter;
      public string InputString { get; private set; }
      public int OutputValue { get { return _valueConverter(InputString); } }
      public MyClass(string inputString, Func<string, int> valueConverter)
      {
        _valueConverter = valueConverter;
        this.InputString = inputString;
      }
    }
    // As a lambda
    MyClass mC = new MyClass("2", input => int.Parse(input));
