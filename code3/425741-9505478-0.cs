    private string previousString = "";
    private static void Port_DataReceived(object sender, 
                                          SerialDataReceivedEventArgs e)
    {
        SerialPort spL = (SerialPort) sender;
        int bufSize = 20;
        Byte[] dataBuffer = new Byte[bufSize];
        Console.WriteLine("Data Received at"+DateTime.Now);
        Console.WriteLine(spL.Read(dataBuffer, 0, bufSize));
        string s = previousString + 
                   System.Text.ASCIIEncoding.ASCII.GetString(dataBuffer);
        previousString = "";
        s = s.Replace("ID:",Environment.NewLine + "ID:");
        if (s.EndsWith("I"))
        {
            previousString = "I";
            s = s.Remove(s.Length-1);
        }
        else if (s.EndsWith("ID"))
        {
            previousString = "ID";
            s = s.Remove(s.Length - 2);
        }
        Console.Write(s);
    }
