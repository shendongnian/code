    internal abstract class BaseClass
    {
    
        protected readonly string Var1;
        protected readonly string Var2;
    
        protected BaseClass(string var1, string var2)
        {
            Var1 = var1;
            Var2 = var2;
        }
    
        protected int DoSomething1(string s)
        {
        }
        public abstract bool DoSomethingSpecific(int i);
    }
