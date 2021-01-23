    public static class ExceptionAssert
    {
        public static void Throws<T>(Action act) where T : Exception
        {
            try
            {
                act();
            }
            catch (T ex)
            {
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} thrown", ex.GetType().Name));
            }
    
            Assert.Fail(string.Format("Expected exception of type {0}", typeof(T).Name));
        }
    }
