    [TestClass]
    public class MyEventClassTest
    {
        [TestMethod]
        public void EventRaised()
        {
            c_0 generated = new c_0();
            generated.raised = false;
    
            var subject = new MyEventClass();
            subject.MyEvent += generated.m_1;
    
            subject.MethodThatRaisesMyEvent();
    
            Assert.IsTrue(generated.raised);
        }
    }
