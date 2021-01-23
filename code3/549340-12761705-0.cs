    SerialPort port;
    string myReceivedLines;
    
       protected override void SolveInstance(IGH_DataAccess DA)
      {
    
        string gcode = default(string);
        DA.GetData(0, ref gcode);
        
        port = new SerialPort(selectedportname, selectedbaudrate, Parity.None, 8, StopBits.One); //Create the serial port
        port.DtrEnable = true;   //enables the Data Terminal Ready (DTR) signal during serial communication (Handshaking)
        port.Open();             //Open the port
        port.DataReceived += this.portdatareceived;
    
        if (gcode == null)
        {
            AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Specify a valid GCode");
            return;
        }
        else
        {
            DA.SetDataList(0,  myReceivedLines);
            port.WriteLine(gcode);
        }    
                  }
    
        private void portdatareceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            myReceivedLines = port.ReadExisting();
        } 
