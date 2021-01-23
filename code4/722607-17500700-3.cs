    private void Run()
    {
        //DataArray
        //Load Everything into the DataArray
        for(/*Everything in the DataArray*/)
        {
            Invoke(new EventHandler(delegate(object sender, EventArgs e) 
            {
                //Load 1 item from DataArray into DataGridView
            }), new object[2] { this, null });
            Thread.Sleep(1); //This number may have to be tweeked
        }
    }
