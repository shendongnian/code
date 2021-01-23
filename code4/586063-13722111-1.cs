    class Program
    {
        static void Main(string[] args)
        {
            DC_A dca = new DC_A();
            DC_B dcb = new DC_B();
            XY xy = new XY();
            xy.goo(dca);
            xy.goo(dcb);
        }
    }
    // base class
    public abstract class BC
    {
        public abstract void foo();
    }
    // derived class A
    public class DC_A : BC
    {
        public override void foo() { }
    }
    // derived class B
    public class DC_B : BC
    {
        public override void foo() { }
    }
    public class XY
    {
        public void goo<T>(T o) where T : BC
        {
            //dynamic dyn = Convert.ChangeType(o, o.GetType());
            dynamic dyn = o;
            gooi(dyn);
        }
        private void gooi(DC_A o)
        {
            o.foo();
            doX(o);
        }
        private void gooi(DC_B o)
        {
            o.foo();
            doY(o);
        }
        private void gooi(BC o)
        {
            o.foo();
        }
        private void doX(DC_A o) { }
        private void doY(DC_B o) { }
    }
