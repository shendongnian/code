    /// <summary>
        /// Throwses the specified action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public static T Throws<T>(Action action) where T : Exception
        {
            try
            {
                action();
            }
            catch (T ex)
            {
                return ex;
            }
    
            Assert.Fail("Expected exception of type {0}.", typeof(T));
            return null;
        }
