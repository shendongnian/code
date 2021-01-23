    public class State : IState
    {
      public IMinimalState generate() { return this; }  // Fixed
      public int getData() { return 1; }
      public int getAnotherData() { return 2; }
    }
