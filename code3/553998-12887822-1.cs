    string selectedportname = default(string); 
    DA.GetData(1, ref selectedportname); 
    int selectedbaudrate = default(int); 
    DA.GetData(2, ref selectedbaudrate); 
    bool connecttodevice = default(bool); 
    DA.GetData(3, ref connecttodevice); 
    SerialPort port = new SerialPort(selectedportname, selectedbaudrate, Parity.None, 8, StopBits.One);   
    port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
    DA.SetDataList(0, myReceivedLines);   
    port.Open();  // optional  I usually open it at the time that I initialize it. you can check `port.IsOpen()`
                  // and Open it if it is false.
