    public void AddFighter_Handler(Response response)
    {
        System.Threading.ThreadPool.QueueUserWorkItem(o => {
        #if DEBUG
        Thread.Sleep(3000);
        #endif
        if (response.Status.Error == false)
        {
            fighter = response.Fighter;
        }});
    }
