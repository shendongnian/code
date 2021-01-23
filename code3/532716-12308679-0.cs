    /// <summary>
    /// This method will be called when there's data waiting in the comport buffer
    /// </summary>
    void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
    	//determine the mode the user selected (binary/string)
    	switch (CurrentTransmissionType)
    	{
    		//user chose string
    		case TransmissionType.Text:
    			//read data waiting in the buffer
    			string msg = comPort.ReadExisting();
    			//display the data to the user
    			DisplayData(MessageType.Incoming, msg + "\n");
    			break;
    		//user chose binary
    		case TransmissionType.Hex:
    			//retrieve number of bytes in the buffer
    			int bytes = comPort.BytesToRead;
    			//create a byte array to hold the awaiting data
    			byte[] comBuffer = new byte[bytes];
    			//read the data and store it
    			comPort.Read(comBuffer, 0, bytes);
    			//display the data to the user
    			DisplayData(MessageType.Incoming, ByteToHex(comBuffer) + "\n");
    			break;
    		default:
    			//read data waiting in the buffer
    			string str = comPort.ReadExisting();
    			//display the data to the user
    			DisplayData(MessageType.Incoming, str + "\n");
    			break;
    	}
    }
