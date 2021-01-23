     public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            comboboxDevices.Items.AddRange(devices.ToArray());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboboxDevices.SelectedItem != null)
            {
                var device = (MMDevice)comboboxDevices.SelectedItem;
                progressBar1.Value = (int)(Math.Round(device.AudioMeterInformation.MasterPeakValue * 100));
            }
        }
    }
