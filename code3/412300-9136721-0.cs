    class MyClassTest
    {
        [TestMethod()]
            public void MyMethodTest()
            {
                string action="test";
                Mock<SomeClass> mockSomeClass = new Mock<SomeClass>();
                mockSomeClass.Setup(mock => mock.DoSomething());
                MyClass myClass = new MyClass(mockSomeClass.Object);
                myClass.MyMethod(action);
                mockSomeClass.Verify(mock => mock.DoSomething(), Times.Once());
            }
    }
