        public void TimeoutExample()
        {
            IAsyncResult result;
            Action action = () =>
            {
                // Your code here
            };
            result = action.BeginInvoke(null, null);
            if (result.AsyncWaitHandle.WaitOne(10000))
                Console.WriteLine("Method successful.");
            else
                Console.WriteLine("Method timed out.");
        }
