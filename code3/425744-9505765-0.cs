    private static StringBuilder receiveBuffer = new StringBuilder();
    
    private static void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort spL = (SerialPort) sender;
        int bufSize = 20;
        Byte[] dataBuffer = new Byte[bufSize];
        Console.WriteLine("Data Received at"+DateTime.Now);
        Console.WriteLine(spL.Read(dataBuffer, 0, bufSize));
        string s = System.Text.ASCIIEncoding.ASCII.GetString(dataBuffer);
        //here's the difference; append what you have to the buffer, then check it front-to-back
        //for known patterns indicating fields
        receiveBuffer.Append(s);
        
        var regex = new Regex(@"(ID:\d*? State:\w{2} Zip:\d{5} StreetType:\w*? )");
        Match match;
        do{
           match = regex.Match(receiveBuffer.ToString());
           if(match.Success)
           {
              //"Process" the significant chunk of data
              Console.WriteLine(match.Captures[0].Value);
              //remove what we've processed from the StringBuilder.
              receiveBuffer.Remove(match.Captures[0].Index, match.Captures[0].Length);
           }
        } while (match.Success);
    }
