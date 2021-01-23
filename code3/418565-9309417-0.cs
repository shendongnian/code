    private void Open_Remote_Connection(string strComputer, string strUserName, string strPassword)
    {
    	System.Diagnostics.ProcessStartInfo ProcessStartInfo = new System.Diagnostics.ProcessStartInfo();
    	ProcessStartInfo.FileName = "net";
    	ProcessStartInfo.Arguments = "use \\\\" + strComputer + "\\c$ /USER:" + strUserName + " " + strPassword;
    	ProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    	System.Diagnostics.Process.Start(ProcessStartInfo);
    	System.Threading.Thread.Sleep(2000);
    }
