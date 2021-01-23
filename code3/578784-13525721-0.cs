    TcpClient client = (TcpClient)tcpClient;
    Byte[] bytes = new Byte[10000];
    String data = null;
    int i;
    NetworkStream stream = client.GetStream();
    // Will get data as long as data is available after 1st read
    do
    {
        i = stream.Read(bytes, 0, bytes.Length)
        data = String.Concat(data, System.Text.Encoding.ASCII.GetString(bytes, 0, i));
    }
    while(stream.DataAvailable); 
    // Write the data to console (first time it should be IMEI
    Console.WriteLine(data);	 
    // Write 1 to the stream, note it must probably be byte value 1 -> 0x01
    // Flush output stream after writing to prevent buffering
    data = "";
    // Now try if more data comes in after IMEI and 0x01 reply
    do
    {
        i = stream.Read(bytes, 0, bytes.Length)
        data = String.Concat(data, System.Text.Encoding.ASCII.GetString(bytes, 0, i));
    }
    while(stream.DataAvailable);
    // Write date to console - move inside the while loop if data keeps coming in
    Console.WriteLine(data);	 
