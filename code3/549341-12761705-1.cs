    SerialPort port;
    string myReceivedLines;
    
       protected override void SolveInstance(IGH_DataAccess DA)
      {
    
        string gcode = default(string);
        DA.GetData(0, ref gcode);
        
        port = new SerialPort(selectedportname, selectedbaudrate, Parity.None, 8, StopBits.One);
        port.DtrEnable = true;   
        port.Open();            
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
