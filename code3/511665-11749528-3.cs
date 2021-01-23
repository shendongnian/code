        Timer timer;
        Computer myComputer;
    
        public Form1()
        {
            InitializeComponent();
            myComputer = new Computer();
            myComputer.Open();
            myComputer.GPUEnabled = true;
            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
         }
        void timer_Tick(object sender, EventArgs e)
        {
            foreach (var hardwareItem in myComputer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.GpuNvidia)
                {
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            MessageBox.Show(String.Format("The current temperature is {0}", sensor.Value));
                        }
                    }
                }
            }
        }
