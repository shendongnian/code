     // Don't use the b.Length in this command:
     string hexStr = ConvertAsciiToHex(Encoding.ASCII.GetString(b, 0, b.Length));
     // use k instead, the numbers actually read, not the length of the buffer.
     string hexStr = ConvertAsciiToHex(Encoding.ASCII.GetString(b, 0, k)); 
     while (socket.Poll(-1, SelectMode.SelectRead))
     {
         // b has been allocated, don't need this
         // b = new byte[1000];
         k = socket.Receive(b);
         if (k > 0)
         {
             count++;
             Console.WriteLine("Reading Client Data - Count - " + count.ToString() + " and lenght " + k.ToString();
            // use k not Length
            hexStr = ConvertAsciiToHex(Encoding.ASCII.GetString(b, 0, k /*b.Length*/));
            File.WriteAllText(@"C:\ClientFiles\testData" + count.ToString(), hexStr);
         }
    }
