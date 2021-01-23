    public sealed class MyExpectedException : ExpectedExceptionBaseAttribute
    {
        private Type _expectedExceptionBaseType;
        public MyExpectedException(Type expectedExceptionType)
        {
            _expectedExceptionBaseType = expectedExceptionType;
        }
        protected override void Verify(Exception exception)
        {
            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.GetType().IsInstanceOfType(typeof(_expectedExceptionBaseType)) || 
                          exception.GetType().IsSubclassOf(typeof(_expectedExceptionBaseType)));
        }
    }
