    using (var com3 = new SerialPort("COM3"))
    {
        if (!com3.IsOpen) com3.Open();
        for (int ii = 0; ii < 10; ++ii)
        {
            com3.WriteLine("AT");
            com3.WriteLine("AT+CMGF=1");
            com3.WriteLine(String.Format("AT+CMGS=\"{0}\"", MobileNo));
            com3.WriteLine(MsgTxt);
        }
    }
