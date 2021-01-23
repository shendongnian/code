    private static var previousStringPerPort = new Dictionary<SerialPort,string>();
    private static void Port_DataReceived(object sender, 
                                          SerialDataReceivedEventArgs e)
    {
        SerialPort spL = (SerialPort) sender;
        int bufSize = 20;
        Byte[] dataBuffer = new Byte[bufSize];
        Console.WriteLine("Data Received at"+DateTime.Now);
        Console.WriteLine(spL.Read(dataBuffer, 0, bufSize));
        if (!previousStringPerPort.ContainsKey(spL))
            previousStringPerPort[spL] = "";
        string s = previousStringPerPort[spL] + 
                   System.Text.ASCIIEncoding.ASCII.GetString(dataBuffer);
        s = s.Replace("ID:",Environment.NewLine + "ID:");
        if (s.EndsWith("I"))
        {
            previousStringPerPort[spL] = "I";
            s = s.Remove(s.Length-1);
        }
        else if (s.EndsWith("ID"))
        {
            previousStringPerPort[spL] = "ID";
            s = s.Remove(s.Length - 2);
        }
        Console.Write(s);
    }
