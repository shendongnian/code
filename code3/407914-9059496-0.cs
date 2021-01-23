     public class FilterCtiCallLog
    {
        private int RequestCount = 0;
        private AsyncOperation createCallsAsync = null;
        private SendOrPostCallback ctiCallsRetrievedPost;
        public void CreateFilteredCtiCallLogSync()
        {
            createCallsAsync = AsyncOperationManager.CreateOperation(null);
            ctiCallsRetrievedPost = new SendOrPostCallback(CtiCallsRetrievedPost);
            CreateFilteredCtiCallLog();
        }
        private void CreateFilteredCtiCallLog()
        {
            int count=0;
            //do the job
            //............
            //...........
            //Raise the event
            createCallsAsync.Post(CtiCallsRetrievedPost, new CtiCallsRetrievedEventArgs(count));
            //...........
            //...........
        }
        public event EventHandler<CtiCallsRetrievedEventArgs> CtiCallsRetrieved;
        private void CtiCallsRetrievedPost(object state)
        {
            CtiCallsRetrievedEventArgs args = state as CtiCallsRetrievedEventArgs;
            if (CtiCallsRetrieved != null)
                CtiCallsRetrieved(this, args);
        }
    }
