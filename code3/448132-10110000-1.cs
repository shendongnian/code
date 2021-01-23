    public class MyState {
      public static readonly MyState Passed = new MyStatePassed();
      public static readonly MyState Failed = new MyStateFailed();
      public virtual void SomeLogic() {
        // default logic, or make it abstract
      }
      class MyStatePassed : MyState {
        public MyStatePassed() : base(1, "OK") { }
      }
      class MyStateFailed : MyState {
        public MyStateFailed() : base(2, "Error") { }
        public override void SomeLogic() { 
          // Error specific logic!
        }
      }
      ...
    }
