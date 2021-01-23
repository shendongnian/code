    public interface IMyThing
    {
        void Function1();
    }
    public abstract class BaseMyThing : IMyThing
    {
        // Implement a version of Function1, but Function 2-5 is up to the concrete class to do
        public void Function1()
        {
            // Do stuff.
        }
    }
    public interface IMyThingConcrete{
      void FunctionConcrete();
    }
    public class ConcreteMyThing : BaseMyThing, IMyThingConcrete
    {
        public void FunctionConcrete() { /* something */ }
    }
