    using System;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    /// <summary>
    /// support halting a workflow and waiting for a finish request
    /// </summary>
    public class MockWorker
    {
        private readonly DateTime? _end;
        private volatile bool _shouldStop;
        /// <summary>
        /// Create a worker object
        /// </summary>
        /// <param name="timeoutInMilliseconds">How long before DoWork will timeout.  default - Null will not timeout.</param>
        public MockWorker(int? timeoutInMilliseconds = null)
        {
            if (timeoutInMilliseconds.HasValue)
                _end = DateTime.Now.AddMilliseconds(timeoutInMilliseconds.Value);
        }
        /// <summary>
        /// Instruct DoWork to complete
        /// </summary>
        public void RequestStop()
        {
            _shouldStop = true;
        }
        /// <summary>
        /// Do work async will run until either timeoutInMilliseconds is exceeded or RequestStop is called.
        /// </summary>
        public async Task DoWorkAsync()
        {
            while (!_shouldStop)
            {
                await Task.Delay(100);
                if (_end.HasValue && _end.Value < DateTime.Now)
                    throw new AssertFailedException("Timeout");
            }
        }
        /// <summary>
        /// Do work async will run until either timeoutInMilliseconds is exceeded or RequestStop is called.
        /// </summary>
        /// <typeparam name="T">Type of value to return</typeparam>
        /// <param name="valueToReturn">The value to be returned</param>
        /// <returns>valueToReturn</returns>
        public async Task<T> DoWorkAsync<T>(T valueToReturn)
        {
            await DoWorkAsync();
            return valueToReturn;
        }
    }
