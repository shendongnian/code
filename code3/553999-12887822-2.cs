    protected override void SolveInstance(IGH_DataAccess DA)
    {
        if(port == null)
        {
            string selectedportname = default(string);
            DA.GetData(1, ref selectedportname);
            int selectedbaudrate = default(int);
            DA.GetData(2, ref selectedbaudrate);
            bool connecttodevice = default(bool);
            DA.GetData(3, ref connecttodevice);
            port = new SerialPort(selectedportname, selectedbaudrate, Parity.None, 8, StopBits.One);
            if (connecttodevice == true)
            {
                port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                DA.SetDataList(0, myReceivedLines);
            }
            port.DtrEnable = true;
            port.Open();
        }
            
        bool homeall = default(bool);
        DA.GetData(5, ref homeall);
        if (homeall == true)
        {
            port.Write("g28");
        }
    }   
