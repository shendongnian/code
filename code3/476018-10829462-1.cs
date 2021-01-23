    // A buffer for the incoming data strings.
    string buffer = string.Empty;
                
    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
      // buffer up the latest data.
      buffer += serialPort1.ReadExisting();;
        
      // there could be more than one packet in the data so we have to keep looping.
      bool done = false;
      while (!done)
        {
           // check for a complete message.
           int start = buffer.IndexOf(":");
           int end = buffer.IndexOf(";");
           if (start > -1 && end > -1 && start < end)
           {
              // A complete packet is in the buffer.
              string packet = buffer.Substring(start + 1, (end - start) - 1);
        
              // remove the packet from the buffer.
              buffer = buffer.Remove(start, (end - start) + 1);
        
              // split the packet up in to it's parameters.
              string[] parameters = packet.Split('*');
              rx1 = parameters[0];
              ry1 = parameters[1];
              dot = parameters[2];
                     
           }
        else
           done = true;
    }
