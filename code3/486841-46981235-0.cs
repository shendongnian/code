    public class TestClass
    {
        public delegate void TestDelagate(TestClass instance, string test);
        private List<TestDelagate> delagates = new List<TestDelagate>();
        public TestClass()
        {
            foreach (MethodInfo method in this.GetType().GetMethods())
            {
                if (TestAttribute.IsTest(method))
                {
                    TestDelegate newDelegate = (TestDelagate)Delegate.CreateDelegate(typeof(TestDelagate), null, method);
                    delegates.Add(newDelegate);
                    //Invocation:
                    newDelegate.DynamicInvoke(this, "hello");
                }
            }
        }
        [Test]
        public void TestFunction(string test)
        {
    
        }
    }
