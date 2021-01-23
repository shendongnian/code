    interface ITest
    {
        public int MyProperty { get; set; }
    }
    public class TestClass : ITest
    {
        public int MyProperty
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
