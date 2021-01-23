    public interface ITest
    {
        void SomeMethod();
        void SomeMethod2();
    }
    
    public ITest : ITest
    {
        
        void ITest.SomeMethod() {} //explicit implentation
        public void SomeMethod2(){} //implicity implementation
    }
