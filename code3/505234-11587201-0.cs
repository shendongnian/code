    public class OuterClassBase
    {
        private class PrivateInnerClass : ProtectedInnerClass
        {
        }
        protected abstract class ProtectedInnerClass
        {
            public void DoSomething() { }
        }
        protected ProtectedInnerClass ProtectedInnerClassFactoryMethod()
        {
            return new PrivateInnerClass();
        }
    }
    
    public class OuterClassDerived : OuterClassBase
    {
        public OuterClassDerived()
        {
            ProtectedInnerClass o = ProtectedInnerClassFactoryMethod();
            o.DoSomething();
        }
    } 
