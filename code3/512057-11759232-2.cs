    public interface IMyDataContextCalls
    {
        void Save();
        IEnumerable<Product> GetOrders();
    }
    // this will be your DataContext wrapper
    // this wll act as your domain repository
    public class MyDataContextCalls : IMyDataContextCalls
    {
        public MyDataContextCalls(DataClasses1DataContext context)
        {
            this.Context = context;
        }
        public void Save()
        {
            this.Context.SubmitChanges();
        }
        public IEnumerable<Product> GetOrders()
        {
            // place here your query logic
            return this.Context.Products.AsEnumerable();
        }
        private DataClasses1DataContext Context { get; set; }
    }
    // this will be your domain object
    // this object will call your repository wrapping the DataContext
    public class MyCommand
    {
        private IMyDataContextCalls myDataContext;
        public MyCommand(IMyDataContextCalls myDataContext)
        {
            this.myDataContext = myDataContext;
        }
        public bool myDomainRule = true;
        // assume this will be the SUT (Subject Under Test)
        public void Save()
        {
            // some business logic
            // this logic will be tested
            if (this.myDomainRule == true)
            {
                this.myDataContext.Save();
            }
            else
            {
                // handle your domain validation  errors
                throw new InvalidOperationException();
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
            //auto mock example:
            var fix = new Fixture().Customize(new AutoMoqCustomization());
            var sut = fix.CreateAnonymous<MyCommand>();
            sut.myDomainRule = false;
            sut.Invoking(x => x.Save())
                .ShouldThrow<InvalidOperationException>();
        }
        public class MyFakeDataContextFake : IMyDataContextCalls
        {
            public void Save()
            {
                // do nothing, since you do not care in the logic of this method,
                // remember your goal is to test the domain object logic
            }
            public IEnumerable<Product> GetOrders()
            {
                // we do not care on this right now because we are testing only the save method
                throw new NotImplementedException();
            }
        }
    }
