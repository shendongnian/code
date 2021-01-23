    public class Test
    {
        public Test(Test test)
        {
            // Do what you want...
        }
    }
    List<Test> tests = new List<Test>() { new Test(null) };
    List<Test> results = DeepCopyList(tests);  
