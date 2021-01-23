    public void CloseIt()
    {
        System.Threading.Thread.Sleep(2000);
        Microsoft.VisualBasic.Interaction.AppActivate( 
             System.Diagnostics.Process.GetCurrentProcess().Id);
        SendKeys.SendWait(" ");
    }
