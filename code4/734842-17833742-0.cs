    public delegate void DoAsync();
    private void button1_Click(object sender, EventArgs e)
    {
       DoAsync async = new DoAsync(GetBatteryDetails);
       async.BeginInvoke(null, null);
    }
    public void GetBatteryDetails()
    {
       int i = 0;
       PowerStatus ps = SystemInformation.PowerStatus;
       while (true)
       {
         if (this.InvokeRequired)
             this.Invoke(new Action(() => this.Text = ps.BatteryLifePercent.ToString() + i.ToString()));
         else
             this.Text = ps.BatteryLifePercent.ToString() + i.ToString();
         i++;
       }
    }
