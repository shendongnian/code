    private bool isFirewallEnabled()
    {
        ProcessStartInfo info = null;
        string result = string.Empty;
        try
        {
           using (Process proc = new Process())
           {
               string args = string.Format(CultureInfo.InvariantCulture, "advfirewall firewall show rule name=\"{0}\"", this.ProductName);
               info = new ProcessStartInfo("netsh", args);
               proc.StartInfo = info;
               proc.StartInfo.UseShellExecute = false;
               proc.StartInfo.CreateNoWindow = true;
               proc.StartInfo.RedirectStandardOutput = true;
               proc.Start();
               while ((result = proc.StandardOutput.ReadLine()) != null)
               {
                   if (result.Replace(" ", String.Empty) == "Enabled:Yes")
                   {
                       return true;
                   }
                }
            }
        }
        catch (Exception ex)
        {
           MessageBox.Show(ex.Message);
        }
        return false;
    }
