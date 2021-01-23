    interface IAmFat
    {
        void Method1();
        void Method2();
        ...
        void MethodN();
    }
    interface IAmSegregated
    {
        void Method1();
    }
    class FatAdapter : IAmSegregated
    {
        private readonly IAmFat fat;
        public FatAdapter(IAmFat fat)
        {
            this.fat = fat;
        }
        public void Method1()
        {
            this.fat.Method1();
        }
    }
