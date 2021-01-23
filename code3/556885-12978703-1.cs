    public void InitFooFuncOnFooMock(Mock<IFoo> fooMock, string a, bool b = false)
    {
        if(!b)
        {
            fooMock.Setup(mock => mock.Foo(a, b)).Returns(false);
        }
        else
        {
            ...
        }
    }
