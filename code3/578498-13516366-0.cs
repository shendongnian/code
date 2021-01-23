      public class Foo : IDispatch
      {
        public virtual void Dispatch()
        {
        }
      }
      public class Bar : Foo
      {
        public override void Dispatch()
        {
          base.Dispatch();
        }
      }
