    // ***Declare a System.Threading.CancellationTokenSource.
    CancellationTokenSource cts;
    public async void LoadData()
    {
       // ***Instantiate the CancellationTokenSource.
        cts = new CancellationTokenSource();
        await Task.Run(
            () =>
                {
                    Measurements = DataContext.Measurements
                                      .Where(m => m.MeasureDate = DateTime.Today)
                                      .ToList();
                }, cts);
    
    }
        //I dont know what front end you using but in WPF for example on the tab event
        <TabControl SelectionChanged="OnSelectionChanged" ... />
    
    private void OnSelectionChanged(Object sender, SelectionChangedEventArgs args)
    {
        TabItem item = sender as TabItem; //The sender is a type of TabItem...
    
        if (item != null)
        {
             if (cts != null)
             {
                //This cancels the current long Running task.
                cts.Cancel();
                
                //call for next tab with filter LoadData(filter);
             }
        }
    }
