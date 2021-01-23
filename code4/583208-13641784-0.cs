    public interface IResettable
    {
        void Reset();
    }
    public class myClass : myInheritage, IResettable
    {
        public void Reset() { ... }
    }
