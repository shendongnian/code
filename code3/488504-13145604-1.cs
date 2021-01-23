    // create a new printer
    MP2Bluetooth bt = new MP2Bluetooth();
    
    // connect to the printer
    bt.ConnectPrinter("<MAC ADDRESS>", "<PIN>");
    
    // write the header and data to the printer
    bt.Write("! CISDF\r\n");
    bt.Write("cmlogo.pcx\r\n");
    bt.Write(String.Format("{0:X8}\r\n", Properties.Resources.cmlogo.Length));
    bt.Write("0000\r\n");     // checksum, 0000 => ignore checksum verification
    bt.Write(Properties.Resources.cmlogo);
    
    // gracefully close our connection and disconnect
    bt.Close();
    bt.DisconnectPrinter();
