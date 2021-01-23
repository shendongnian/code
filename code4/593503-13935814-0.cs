    public async bool UnloadData()
    {
        if(...)
        {
            await Task.Factory.StartNew(() => 
                {
                    LaunchMyTimeConsumingMethod();
                });
            return true;//Only when my time consuming method ends
        }
        //[...]
    }
