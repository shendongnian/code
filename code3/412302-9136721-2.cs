    class MyClassTest
    {
        [TestMethod]
        public void MyMethodTest()
        {
            string action = "test";
            Mock<SomeClass> mockSomeClass = new Mock<SomeClass>();
            mockSomeClass.Setup(mock => mock.DoSomething());
            MyClass myClass = new MyClass(mockSomeClass.Object);
            myClass.MyMethod(action);
            // Explicitly verify each expectation...
            mockSomeClass.Verify(mock => mock.DoSomething(), Times.Once());
            // ...or verify everything.
            // mockSomeClass.VerifyAll();
        }
    }
