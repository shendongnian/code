    public TheKindOfTestIWantToDo()
    {
       var actualB = new B();
       var mockIB = new Mock<IB>();
       mockIB.Setup(b => b.Foo()).Returns(() => actualB.Foo())
       var a = new A { B = mockIB };
       //do stuff with A, methods invoked on splitter IB get passed to both supplied instances
       //of IB (actualB, and the mockIB). Allowing me to verify the calls as well as have the methods invoked on the actual B object.
    }
