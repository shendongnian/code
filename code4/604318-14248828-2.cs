    public static class MockExtensions
    {
        public static void VerifyAny<T>(this Mock<T> mock, params Expression<Action<T>>[] expressions)
            where T: class
        {
            List<MockException> exceptions = new List<MockException>();
            bool success = false;
            foreach (var expression in expressions)
            {
                try
                {
                    mock.Verify(expression);
                    success = true;
                    break;
                }
                catch (MockException ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (!success)
            {
                throw new AggregateException("None of the specified methods were invoked.", exceptions);
            }
        }
    }
