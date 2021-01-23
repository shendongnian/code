    interface IMyDataContextCalls
    {
        void Save();
        IEnumerable<Order> GetOrders();
    }
    // this will be your DataContext wrapper
    // this wll act as your domain repository
    class MyDataContextCalls : IMyDataContextCalls
    {
        private DataContext context;
        public MyDataContextCalls(DataContext context)
        {
            this.context = context;
        }
        public void Save()
        {
            this.context.SubmitChanges();
        }
        public IEnumerable<Order> GetOrders()
        {
            // place here your query logic
            return this.context.Orders.AsEnumerable();
        }
    }
    // this represent your domain object, 
    // this object calls your repository wrapping your DataContext
    class MyCommand
    {
        private IMyDataContextCalls myDataContext;
        public MyCommand(IMyDataContextCalls myDataContext)
        {
            this.myDataContext = myDataContext;
        }
        // assume this will be the SUT (Subject Under Test)
        public void Save()
        {
            // some business logic
            // this logic will be tested
            if (mydomainrule == true)
            {
                this.myDataContext.Save();
            }
        }
    }
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void MyTestMethod()
        {
            // in this test your mission is to test the logic inside the 
            // MyCommand.Save method
            // create the mock, you could use a framework to auto mock it
            // or create one manually
            // manual example:
            var m = new MyCommand(new MyFakeDataContextFake());
            m.Invoking(x => x.Save())
                //add here more asserts, maybe asserting that the internal
                // state of your domain object was changed
                // your focus is to test the logic of the domain object
                .ShouldNotThrow();
        }
        class MyFakeDataContextFake : IMyDataContextCalls
        {
            public void Save()
            {
                // do nothing, since you do not care in the logic of this method,
                // remember your goal is to test the domain object logic
            }
            public IEnumerable<Order> GetOrders()
            {
                // we do not care on this right now because we are testing only the save method
                throw new NotImplementedException();
            }
        }
    }
