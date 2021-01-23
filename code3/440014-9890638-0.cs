    class YourForm : Form
    {
      private ManualResetEvent terminate = new ManualResetEvent(false);
    
      private void YourThread()
      {
        while (!terminate.WaitOne(0))
        {
          // Do some more work here.
        } 
      }
    
      private void ButtonAbort_Click(object sender, EventArgs args)
      {
        terminate.Set();
      }
    }
