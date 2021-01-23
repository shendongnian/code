    public void search()
    {
        try
        {
            Task.Factory.StartNew(() =>
            {
                try{
                Parallel.ForEach(source,
                                 new ParallelOptions
                                 {
                                     MaxDegreeOfParallelism = 5 //limit number of parallel threads here 
                                 },
                                 file =>
                                 {
                                    // check my file before adding to my Listbox
                                 });
                }).ContinueWith
                    (t =>
                    {
                        OnFinishSearchEvent();
                    }
            , TaskScheduler.FromCurrentSynchronizationContext() //to ContinueWith (update UI) from UI thread
            );
            catch(Exception ex){
            }
        }
        catch (Exception ex)
        {
    
        }
    }
