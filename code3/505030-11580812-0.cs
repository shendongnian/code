    public class TestList
    {
       public TestList() {
          wow = new List<TestModel>();
       }
        public List<TestModel> wow { get; private set; }//if you do this way, you can have a private setter
    }
