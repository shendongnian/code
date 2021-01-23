    public class MyWCFClient:ClientBase<IMyWCFServiceContract>, IMyWCFServiceContract
    {
        //Implement the interface and call the channel
        public void SyncClient(List<Client> clients)
        {
            this.Channel.SyncClient(clients);
        }
    }
