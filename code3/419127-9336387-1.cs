    client.GetDataAsync();
    client.GetDataCompleted += new EventHandler<GetDataCompletedEventArgs>(GetDataCompleted);
	void GetDataCompleted(object sender, GetDataCompletedEventArgs e)
	{
	  // Loop through the data
	  // ...
	  textBlock1.Text= "test1";
	  //////Dispatcher should not be needed here as this IS on the main UI thread
	  Dispatcher.BeginInvoke(() => textBlock1.Text= "test2" );
	  //////Everything that happens here should NOT be on the main UI thread, thus the cross-thread access exception
	  //////You can do Dispatcher.CheckAccess to determine if you need to invoke or not
	  //////Notice the newCopyOfDataToBeWritten. This is a closure, 
	  //////so using the same referenced object will result in errant data as it loops
	  //////Also, doing it this way does not guarantee any order that this will be written out
	  //////This will utilize the parallel fully, but there are ways to force the order
	  var task = Task.Factory.StartNew(()=>
	    {
	      Dispatcher.BeginInvoke(()=>textBlock1.Text += newCopyOfDataToBeWritten)
	    }
	  );
	  // ...
	  ///////I assume this is the end of the loop?
	  Debug.WriteLine("done");
	}
