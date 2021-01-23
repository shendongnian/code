    public class MyForm : Form
    {
        private System.Threading.Timer gpuUpdateTimer;
        private System.Threading.Timer cpuUpdateTimer;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                gpuUpdateTimer = new System.Threading.Timer(GpuView, null, 0, 1000);
                cpuUpdateTimer = new System.Threading.Timer(CpuView, null, 0, 100);
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
            // do not access control directly, use BeginInvoke!
            TemperatureLabel = sensor.Value.ToString() + "c" // whatever
        }
        private void GpuView(object state)
        {
            // do your stuff here
            // 
            // do not access control directly, use BeginInvoke!
            GpuText = sensor.Value.ToString() + "c";  // whatever
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (cpuTimer != null)
                {
                    cpuTimer.Dispose();
                }
                if (gpuTimer != null)
                {
                    gpuTimer.Dispose();
                }
            }
            base.Dispose(disposing);
        }
