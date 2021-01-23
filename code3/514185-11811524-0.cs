    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if(!DesignMode)
        {
            System.Threading.Timer gpuUpdateTimer = new System.Threading.Timer(GpuView, null, 0, 1000);
            System.Threading.Timer cpuUpdateTimer = new System.Threading.Timer(CpuView, null, 0, 100);
        }
    }
    private string GpuText
    {
        set
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => gpuLabel.Text = value), null);
            }
        }
    }
    private string TemperatureLabel
    {
        set
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => temperatureLabel.Text = value), null);
            }
        }
    }
    private void CpuView(object state)
    {
        // do your stuff here
        // 
        // do not access control direcly, use BeginInvoke !
        TemperatureLabel = sensor.Value.ToString() + "c" // whatever
    }
    private void GpuView(object state)
    {
        // do your stuff here
        // 
        // do not access control direcly, use BeginInvoke !
        GpuText = sensor.Value.ToString() + "c";  // whatever
    }
