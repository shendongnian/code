    if (port == null) 
    { 
        string selectedportname = default(string); 
        DA.GetData(1, ref selectedportname); 
        int selectedbaudrate = default(int); 
        DA.GetData(2, ref selectedbaudrate); 
        bool connecttodevice = default(bool); 
        DA.GetData(3, ref connecttodevice); 
 
        //Assigning an object to the field within the SolveInstance method() 
        port = new SerialPort(selectedportname, selectedbaudrate, Parity.None, 8, StopBits.One); 
 
        //Enables the data terminal ready (dtr) signal during serial communication (handshaking) 
        port.DtrEnable = true; 
       
    } 
    if (connecttodevice == true) 
    { 
        port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler); 
        DA.SetDataList(0, myReceivedLines); 
        port.Open(); 
    } 
    else
    {
        if(port.IsOpen)
        {
            port.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler); 
           // DA.SetDataList(0, myReceivedLines); // Not sure how you want to remove this
            port.Close();
        } 
    }
        
