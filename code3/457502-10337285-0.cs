    public class SomeException : Exception { }
    
    public class Foo
    {
        public virtual int Execute()
        {
            try
            {
                GetFiles();
            }
            catch (SomeException)
            {
                return 1;
            }
            return 0;
        }
    
        public virtual void GetFiles()
        {
            //...
        }
    }
    
    [Test]
    public void FooTest()
    {
        var fooUnderTest = new Mock<Foo>();
        fooUnderTest.CallBase = true;
        fooUnderTest.Setup(f => f.GetFiles()).Throws(new SomeException());
        var result = fooUnderTest.Object.Execute();
        Assert.AreEqual(1, result);
    }
