    class MyClass
    {
      public string InputString { get; private set; }
      public int OutputValue { get; set; }
      public MyClass(string inputString)
      {
        this.InputString = inputString;
      }
      public void Transform(Func<string, int> f){
        OutputValue = f(InputString);
      }
    }
    MyClass mC = new MyClass("abcd");
    mC.Transform(c=> c.Sum(c=> ((int)c));//OutputValue is changed
    mC.Transform(c=> (int)c.Average(c=> ((int)c));//OutputValue is changed
