        Timer timer;
        Computer myComputer;
        ISensor GPUTemperatureSensor;
    
        public Form1()
        {
            InitializeComponent();
            myComputer = new Computer();
            myComputer.Open();
            myComputer.GPUEnabled = true;
            foreach (var hardwareItem in myComputer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.GpuNvidia)
                {
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            GPUTemperatureSensor = sensor;
                            
                        }
                    }
                }
            }
            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
         }
        void timer_Tick(object sender, EventArgs e)
        {
            if(GPUTemperatureSensor != null)
            {
                GPUTemperatureSensor.Hardware.Update();//This line refreshes the sensor values
                textBox1.Text = String.Format("The current temperature is {0}", GPUTemperatureSensor.Value);
            }
            else
            {
                textBox1.Text = "Could not find the GPU Temperature Sensor. Stopping.";
                timer.Stop(); 
            }
        }
