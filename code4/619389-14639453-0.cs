	private void COM_Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
	{
		var port = (SerialPort)sender;
		while (port.BytesToRead > 0)
		{
			var data = (byte)port.ReadByte();
			Read(data);
		}
	}
	private void Read(byte value)
	{
		// Append Byte to buffer
		System.Buffer.BlockCopy(Buffer, 1, Buffer, 0, Comm_Tools.HEADERLENGTH - 1);
		Buffer[Comm_Tools.HEADERLENGTH - 1] = value;
		// Check for valid Packet
		if (Comm_Tools.IsValidHeader(Buffer))
		{
			// Yeah! Gotcha :-)
			// Now copy your Packet from the Buffer to your struct/whatever
		}
	}
