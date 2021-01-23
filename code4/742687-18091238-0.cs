        public Future(FutureDelegate<T> del, int timeout_ms)
        {
            Del = del;
            Result = del.BeginInvoke(null, null);
            if (!Result.IsCompleted)
            {
                if (!Result.AsyncWaitHandle.WaitOne(timeout_ms))
                {
                    HasTimedOut = true;
                }
                else
                {
                    HasTimedOut = false;
                }
            }
            PValue = Del.EndInvoke(Result);             
        }
