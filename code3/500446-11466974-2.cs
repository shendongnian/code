    public void Worker_DoWork(object sender, DoWorkEventArgs e)
    {
       foreach (var someParameter in parameterList) // Long-running loop 
       {
         var data = LoadData(someParameter); // Load data for row X
         this.Invoke(new Action<object>(UpdateRow),new[]{data});  // Update on UI-thread
       }
    }
    public void UpdateRow(object data)
    {
       // Code to populate DataGrid row X with data from argument
    }
