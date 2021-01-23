        protected override void FlushAsync(AsyncContinuation asyncContinuation)
        {
            this.flushAllContinuation = asyncContinuation;
            this.ProcessPendingEvents(null);        // Added to make this flush synchronous.
        }
