    public class RuntimeFlagIComposite : I
    {
        private A a;
        private B b;
        public RuntimeFlagIComposite(A a, B b)
        {
            this.a = a;
            this.b = b;
        }
        void I.Method()
        {
            var instance = IsRuntimeFlag ? this.a : this.b;
            instance.Method();
        }
    }
