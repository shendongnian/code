    public interface IUnified
    {
        void M1();
        void M2();
    }
    public class UnifiedAdapter : IUnified
    {
        private Action m1;
        private Action m2;
        public UnifiedAdapter(A a)
        {
            m1 = () => a.M1();
            m2 = () => a.M2();
        }
        public UnifiedAdapter(B b)
        {
            m1 = () => b.M1();
            m2 = () => b.M2();
        }
        public UnifiedAdapter(C c)
        {
            m1 = () => c.M1();
            m2 = () => c.M2();
        }
        public M1()
        {
            m1();
        }
        public M2()
        {
            m2();
        }
    }
