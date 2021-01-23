    private void SetIP(Button sender, string arg)  //To set IP with elevated cmd prompt
    {
        try
        {
            if (sender.Background == Brushes.Cyan )
            { 
                MessageBox.Show("Already Selected...");
                return;
            }
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
            psi.UseShellExecute = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.Verb = "runas";
            psi.Arguments = arg;
            Process.Start(psi);
            if (sender == EthStatic ||  sender == EthDHCP )
            {
                EthStatic.ClearValue(Button.BackgroundProperty);
                EthDHCP.ClearValue(Button.BackgroundProperty);
                sender.Background = Brushes.Cyan;
             }
            if (sender == WIFIStatic || sender == WIFIDhcp)
            {
                WIFIStatic.ClearValue(Button.BackgroundProperty);
                WIFIDhcp.ClearValue(Button.BackgroundProperty);
                sender.Background = Brushes.Cyan;
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
