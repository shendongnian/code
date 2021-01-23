    public static async Task<Exception> AssertThrowsAsync<TException>(Func<Task> func)
        {
            var expected = typeof (TException);
            Exception exception = null;
            Type actual = null;
            try
            {
                await func();
            }
            catch (Exception e)
            {
                actual = e.GetType();
                exception = e;
            }
            Assert.NotNull(exception);
            Assert.Equal(expected, actual);
            return exception;
        }
