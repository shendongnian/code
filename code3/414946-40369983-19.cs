    [TestCaseOrderer("FullNameOfOrderStrategyHere", "OrderStrategyAssemblyName")]
    public class PriorityOrderExamples
    {
        [Fact, TestPriority(5)]
        public void Test3()
        {
            // called third
        }
    
        [Fact, TestPriority(0)]
        public void Test2()
        {
          // called second
        }
   
        [Fact, TestPriority(-5)]
        public void Test1()
        {
           // called first
        }
    
    }
