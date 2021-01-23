    [TestMethod]
    public void TestMethod1()
    {
      WcfClient client = new WcfClient("BasicHttpBinding_IWcf");
      AutoResetEvent waitHandle = new AutoResetEvent(false); 
      GetDataCompletedEventArgs args = null;
      client.GetDataCompleted = (s, e) => {
        args = e.Error;
        waitHandle.Set(); 
      };
      // call the async method
      client.GetDataAsync(arg1, arg2);
      // Wait until the event handler is invoked
      if (!waitHandle.WaitOne(5000, false))  
      {  
        Assert.Fail("Test timed out.");  
      }  
    
      Assert.IfNull(args.Error);
    }
