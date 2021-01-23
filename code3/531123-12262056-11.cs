    private Task funcA()
    {
      return Task.Factory.StartNew(() =>
      {
        try
        {
          //Code running here will be executed on another thread
          //This is where you would put your time consuming work
          //
          //
        }
        catch(Exception ex)
        {
          //Handle any exception locally if needed
          //If you do handle it locally, make sure you throw it again so we can see it in Task.WhenAll
          throw ex;
        }
        //Do any required UI updates after the work
        //We aren't on the UI thread, so you will need to use BeginInvoke
        //'this' would be a reference to your form
        this.BeginInvoke(new Action(() =>
        {
          //...
        }));
      });
    }
