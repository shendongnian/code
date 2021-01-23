    [TestFixture]
    class Test
    {
    
        [TestCase(MyEnum.Foo, false)]
        [TestCase(MyEnum.Bar, true)]
        public void TestMethod(MyEnum myEnum, bool shouldExceptionBeThrown)
        {
            if (shouldExceptionBeThrown)
                Assert.Throws<Exception>(() => MethodUnderTest(myEnum));
            else
                MethodUnderTest(myEnum);
        }
    
        public void MethodUnderTest(MyEnum myEnum)
        {
            if(myEnum == MyEnum.Bar)
                throw new Exception();
        }
    }
    
    internal enum MyEnum
    {
        Foo,
        Bar
    }
