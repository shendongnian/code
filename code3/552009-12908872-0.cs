    /// <summary>
    /// Async Asserts use with Microsoft.VisualStudio.TestPlatform.UnitTestFramework
    /// </summary>
    public static class AsyncAsserts
    {
        /// <summary>
        /// Verifies that an exception of type <typeparamref name="T"/> is thrown when async<paramref name="func"/> is executed.
        /// The assertion fails if no exception is thrown
        /// </summary>
        /// <typeparam name="T">The generic exception which is expected to be thrown</typeparam>
        /// <param name="func">The async Func which is expected to throw an exception</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static async Task<T> ThrowsException<T>(Func<Task> func) where T : Exception
        {
            return await ThrowsException<T>(func, null);
        }
        /// <summary>
        /// Verifies that an exception of type <typeparamref name="T"/> is thrown when async<paramref name="func"/> is executed.
        /// The assertion fails if no exception is thrown
        /// </summary>
        /// <typeparam name="T">The generic exception which is expected to be thrown</typeparam>
        /// <param name="func">The async Func which is expected to throw an exception</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static async Task<T> ThrowsException<T>(Func<Task> func, string message) where T : Exception
        {
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }
            string failureMessage;
            try
            {
                await func();
            }
            catch (Exception exception)
            {
                if (!typeof(T).Equals(exception.GetType()))
                {
                    // "Threw exception {2}, but exception {1} was expected. {0}\nException Message: {3}\nStack Trace: {4}"
                    failureMessage = string.Format(
                        CultureInfo.CurrentCulture,
                        FrameworkMessages.WrongExceptionThrown,
                        message ?? string.Empty,
                        typeof(T),
                        exception.GetType().Name,
                        exception.Message,
                        exception.StackTrace);
                    Fail(failureMessage);
                }
                else
                {
                    return (T)exception;
                }
            }
            // "No exception thrown. {1} exception was expected. {0}"
            failureMessage = string.Format(
                        CultureInfo.CurrentCulture,
                        FrameworkMessages.NoExceptionThrown,
                        message ?? string.Empty,
                        typeof(T));
            Fail(failureMessage);
            return default(T);
        }
        private static void Fail(string message, [CallerMemberName] string assertionName = null)
        {
            string failureMessage = string.Format(
                CultureInfo.CurrentCulture,
                FrameworkMessages.AssertionFailed,
                assertionName,
                message);
            throw new AssertFailedException(failureMessage);
        }
    }
