    public event EventHandler<FriendOfSearchArgs> FirendsOfSearch;
    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Result != null)
        {
            RaiseFriendOfSearch(e.Result);
        }
    }
    protected virtual void RaiseFriendOfSearch(object result)
    {
        var friendOfSearch = FirendsOfSearch;
        if(friendOfSearch != null)
            friendOfSearch(this, new FriendOfSearchArgs(result));
    }
    public class FriendOfSearchArgs : EventArgs
    {
       public FriendOfSearchArgs(object result)
       {
           Result = result;
       }
       public object Result {get; private set;}
    }
