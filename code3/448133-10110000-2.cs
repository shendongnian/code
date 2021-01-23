    public enum MyStateValue { 
      Passed = 1, Failed = 2
    }
    public sealed class MyState {
      public static readonly MyState Passed = new MyState(MyStateValue.Passed, "OK");
      public static readonly MyState Failed = new MyState(MyStateValue.Failed, "Error");
      public MyStateValue Value { get; private set; }
      private MyState(MyStateValue value, string name) {
        ...
      }
    }
