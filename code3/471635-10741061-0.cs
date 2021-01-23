        IAsyncResult _invokeResult; 
  
        PowerShell _ps = PowerShell.Create();
        
        delegate void SetOutput(string value);
        // Monitor the DataAdded
        _ps.Streams.Verbose.DataAdded += new EventHandler<DataAddedEventArgs>(Verbose_DataAdded);
        var sr = new StreamReader(@"C:\MyScript.ps1");
        _ps.AddScript(sr.ReadToEnd());
        _invokeResult = _ps.BeginInvoke<PSObject>(null, null, AsyncInvoke, null);
       void Verbose_DataAdded(object sender, DataAddedEventArgs e)
       {
           System.Diagnostics.Debug.Print( ((PSDataCollection<VerboseRecord>) sender)[e.Index].ToString()) ;
           if (txtOutput.InvokeRequired)
           {
               string msg = ((PSDataCollection<VerboseRecord>) sender)[e.Index].ToString();
               txtOutput.Invoke(new SetOutput(Execute), new object[] { msg} );
           }
       }
       void AsyncInvoke(IAsyncResult ar)
       {
           // end
           try
           {
               _ps.EndInvoke(ar);
           }
           catch (Exception ex)
           {
                 // do something with the error...
           }
      }
    private void Execute(string msg)
            {
                txtOutput.SelectionFont = new Font(txtOutput.SelectionFont.FontFamily, 9.0f);
                txtOutput.AppendText(msg);
                txtOutput.ScrollToCaret();
            }
