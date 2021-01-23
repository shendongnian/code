    TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    Task.Factory.StartNew(() =>
    {
        //load data or perform work on background thread
        var itemList = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            itemList.Add(i);
            System.Threading.Thread.Sleep(1000);
        }
        return itemList;
    }).ContinueWith((itemList) => 
    {
       //get the data from the previous task a continue the execution on the UI thread
       foreach(var item in itemList)
       {
          listBox1.Items.Add("Number cities in problem = " + item.ToString());
       }
    }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);
