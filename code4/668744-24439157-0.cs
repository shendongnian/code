        , null
        , null
        , 0);
    if (mapResult!=0)
    {
        throw new Exception("AddConnection failed");
        // >0? check  http://msdn.microsoft.com/en-us/library/windows/desktop/ms681383(v=vs.85).aspx
    }
   
    // get the remote connection path
    int remoteBufLen = 0; // start with a 0 length buffer
    StringBuilder remotePath = null;
    var connRes = ERROR_MORE_DATA;  
    // call twice if the buffer is too small
    for (int t=0 ; t<2 && connRes == ERROR_MORE_DATA; t++)
    {
        remotePath = new StringBuilder(remoteBufLen);
        // and error is returned 
        // and remoteBufLen holds the required size
        connRes = WNetGetConnection(@"Z:", remotePath, ref remoteBufLen);
    }
    if (connRes != 0)
    {
       throw new Exception("getconnetion failed");
    }
    
    string message1 = String.Format(@"[1] Go to C:\{0}[2] Replace Folder ""myTeX"" with myTeX exist in {1}{0}[3] Open Start menu-->All Programs-->MiKTeX 2.8-->Maintenance-->Settings-->Click on ""Refresh FNDB"" button then wait the process and try again, Good Luck "
    , Environment.NewLine, remotePath);
    
    richTextBox2.Text = message1;
    
