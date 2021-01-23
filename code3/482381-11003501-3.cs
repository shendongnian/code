    class MyClient: ClientBase<IMyService>, IMyService
    {
        public void GetData(string docId)
        {
            Channel.GetData(docId);
        }
    }
