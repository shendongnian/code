    //On PageLoad, populate the grid, and set a timer to repeat ever 60 seconds
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
    	try
    	{
    		RebindData();
    		SetTimer();
    	}
    	catch (SqlException e)
    	{
    		Console.WriteLine(e.Message);
    	}
    }
    
    //Refreshes grid data on timer tick
    protected void dispatcherTimer_Tick(object sender, EventArgs e)
    {
    	RebindData();
    }
    
    //Get data and bind to the grid
    private void RebindData()
    {
    	String selectstatement = "select top 2 ItemID, ItemName,ConsumerName, Street, DOJ from ConsumarTB order by ItemID ";
    	da = new SqlDataAdapter(selectstatement, con);
    	ds = new DataSet();
    	da.Fill(ds);
    	dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
    }
    
    //Set and start the timer
    private void SetTimer()
    {
    	DispatcherTimer dispatcherTimer = new DispatcherTimer();
    	dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
    	dispatcherTimer.Interval = new TimeSpan(0, 0, 60);
    	dispatcherTimer.Start();
    }
