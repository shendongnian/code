    using (var com3 = new SerialPort("COM3"))
    {
        if (!com3.IsOpen) com3.Open();
        for (int ii = 0; ii < 10; ++ii)
        {
            com3.WriteLine("AT" + Environment.NewLine);
            com3.WriteLine("AT+CMGF=1" + Environment.NewLine);
            com3.WriteLine("AT+CMGS=\"" + 03152800485 + "\"" + Environment.NewLine);
            com3.WriteLine("Hello Kashif" + (char)26);
            Thread.Sleep(5000);
        }
        com3.Close();
    }
