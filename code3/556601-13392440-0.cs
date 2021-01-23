    string sFileName; //file name in DOS format (8.3)
    byte[] baBody; //byte array of font file
    string PacketHeader = "! CISDF\r\n{0}\r\n{1}\r\n{2}\r\n";
    //************************
    int CheckSum = 0;
    foreach (byte b in baBody)
      CheckSum += b;
    
    PacketHeader = String.Format(PacketHeader, sFileName, Convert.ToString(baBody.Length, 16).PadLeft(8, '0').ToUpper(), Convert.ToString(65536 - (CheckSum % 65536), 16).PadLeft(4, '0').ToUpper());
    
    List<byte> list = new List<byte>();
    list.AddRange(Encoding.Default.GetBytes(PacketHeader.ToCharArray()));
    list.AddRange(baBody);
    list.AddRange(new byte[] { 0x1B, 0x68, 0x1B, 0x68, 0x1B, 0x68, 0x1B, 0x70, 0x00 });
    
    int PacketSize = list.Count;
    byte[] tmp;
    int sourceIndex = 0;
    
    while (PacketSize / 512 >= 1)
    {
      tmp = list.GetRange(sourceIndex, 512).ToArray();
      int BytesSent = bt.WriteBytesToSerialPort(tmp);
      tmp = null;
      sourceIndex += BytesSent;
      PacketSize -= BytesSent;
      Sleep(100);
    }
    
    if (PacketSize > 0)
    {
      tmp = list.GetRange(sourceIndex, list.Count - sourceIndex).ToArray();
      PacketSize -= bt.WriteBytesToSerialPort(tmp);
      tmp = null;
    }
    
    list.Clear();
    list = null;
