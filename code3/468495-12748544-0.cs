    namespace YourApp
    {
      public partial class frmMain : Form
      {
        // Declare delegate for summary box, frees main thread from dreaded OK click
        private delegate void ShowSummaryDelegate();
        ShowSummaryDelegate ShowSummary;
        /// <summary>
        /// Your message box, edit as needed
        /// </summary>
        private void fxnShowSummary()
        {
          string msg;
          msg = "TEST SEQUENCE COMPLETE\r\n\r\n";
          msg += "Number of tests performed: " + lblTestCount.Text + Environment.NewLine;
          msg += "Number of false positives: " + lblFalsePve.Text + Environment.NewLine;
          msg += "Number of false negatives: " + lblFalseNve.Text + Environment.NewLine;
      
          MessageBox.Show(msg);
        }
        /// <summary>
        /// This callback is used to cleanup the invokation of the summary delegate.
        /// </summary>
        private void fxnShowSummaryCallback(IAsyncResult ar)
        {
          try
          {
            ShowSummary.EndInvoke(ar);
          }
          catch
          {
          }
        }
        /// <summary>
        /// Your bit of code that wants to call a message box
        /// </summary>
        private void tmrAction_Tick(object sender, EventArgs e)
        {
          ShowSummary = new ShowSummaryDelegate(fxnShowSummary);
          AsyncCallback SummaryCallback = new AsyncCallback(fxnShowSummaryCallback);
          IAsyncResult SummaryResult = ShowSummary.BeginInvoke(SummaryCallback, null);
        }
        // End of Main Class
      }
    }
