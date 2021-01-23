    public interface IMyThing
    {
        void Function2();
        void Function3();
        void Function4();
        void Function5();
    }
    public abstract class BaseMyThing
    {
        public void Function1() {}
    }
    public class ConcreteMyThing : BaseMyThing, IMyThing
    {
        public void Function2() { }
        public void Function3() { }
        public void Function4() { }
        public void Function5() { }
    }
