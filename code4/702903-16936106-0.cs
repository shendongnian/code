    interface ITest
    {
        List<ITest> GetAll(string whatever);
    }
    class MyClass : ITest
    {
        public List<ITest> GetAll(string whatever)
        {
            return new List<ITest>();
        }
    }
