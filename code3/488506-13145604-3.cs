    // calculate the checksum for the file
    // get the sum of all the bytes in the data stream
    UInt16 sum = 0;
    for (int i = 0; i < Properties.Resources.cmlogo.Length; i++)
    {
      sum += Convert.ToUInt16(Properties.Resources.cmlogo[ i]);
    }
    // compute the two's complement of the checksum
    sum = (Uint16)~sum;
    sum += 1;
    // create a new printer
    MP2Bluetooth bt = new MP2Bluetooth();
    
    // connect to the printer
    bt.ConnectPrinter("<MAC ADDRESS>", "<PIN>");
    
    // write the header and data to the printer
    bt.Write("! CISDF\r\n");
    bt.Write("cmlogo.pcx\r\n");
    bt.Write(String.Format("{0:X8}\r\n", Properties.Resources.cmlogo.Length));
    bt.Write(String.Format("{0:X4}\r\n", sum));  // checksum, 0000 => ignore checksum
    bt.Write(Properties.Resources.cmlogo);
    
    // gracefully close our connection and disconnect
    bt.Close();
    bt.DisconnectPrinter();
