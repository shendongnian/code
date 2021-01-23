    private void btnReadTag_Click(object sender, EventArgs e)
    {
        serialPort = new SerialPort();// if u r not used Serial Port Tool
        serialPort.PortName = "COM1";
        serialPort.BaudRate = 9600;
        serialPort.DataBits = 8;
        serialPort.Parity = Parity.None;
        serialPort.StopBits = StopBits.One;
        serialPort.Open();
        serialPort1.ReadTimeout = 2000;
        serialPort.DataReceived += new SerialDataReceivedEventHandler(Fun_DataReceived);
        serialPort.Close();
    }
    //Delegate for the Reading the Tag while RFID Card come to the Range.
    string data = string.Empty;
    private delegate void SetTextDeleg(string text);
    void Fun_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        Thread.Sleep(500);
        data = serialPort.ReadLine();
        this.BeginInvoke(new SetTextDeleg(Fun_IsDataReceived), new object[] { data });
    }
    private void Fun_IsDataReceived(string data)
    {
        txtAccessCardNo.Text = data.Trim();
    }
