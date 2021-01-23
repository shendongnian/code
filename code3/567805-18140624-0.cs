    private Window waitView;
    /// <summary>
    /// Closes a displayed WaitView from code.
    /// </summary>
    public void CloseWaitView()
    {
      if(waitView != null)
      {
         // Work on the gui Thread of waitView.
         waitView.Dispatcher.Invoke(new Action(() => close()));
      }
    }
    /// <summary>
    /// Closes a displayed WaitView and releases waitView-Instance.
    /// </summary>    
    private void close()
    {
       waitView.Close();
       waitView = null;
    }   
    /// <summary>
    /// Showes a modal WaitView (Window).
    /// </summary>
    public void ShowWaitView()
    {
      // instance a new WaitViewWindow --> your Window extends Window-Class
      waitView = new WaitViewWindow();
      // prepare a operation to call it async --> your ShowDialog-call
      var asyncCall = new Action(() => waitView.Dispatcher.Invoke(
                                       new Action(() => waitView.ShowDialog())
                                 ));
      // call the operation async
      
      // Argument 1 ar:
      // ar means IAsyncResult (what should be done, when come back from ShowDialog -->     
      // remove view memory with set waitView to null or ... dispose
      // the second argument is an custom parameter you can set to use in ar.AsyncState
      asyncCall.BeginInvoke(ar => waitView = null, null);
      // all from here is done during ShowDialog ...
    }
