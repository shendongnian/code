    public interface IMarkerInterface
    {       
    }
    public class ConcreteObject : IMarkerInterface
    {
    }
    public interface IDoStuffInterface<T>
    {
        void DoStuff(T obj);
    }
    public class ConcreteDoStuff : IDoStuffInterface<ConcreteObject>
    {
        public void DoStuff(ConcreteObject c)
        {
        }
    }
