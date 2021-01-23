    	private bool CheckExistingModemOnComPort(SerialPort serialPort)
    	{
    		if ((serialPort == null) || !serialPort.IsOpen)
        		return false;
    		// Commands for modem checking
    		string[] modemCommands = new string[] { "AT",		// Check connected modem. After 'AT' command some modems autobaud their speed.
    							                    "ATQ0" };	// Switch on confirmations
    		serialPort.DtrEnable = true;	// Set Data Terminal Ready (DTR) signal 
    		serialPort.RtsEnable = true;	// Set Request to Send (RTS) signal
        
    		string answer = "";
    		bool retOk = false;
    		for (int rtsInd = 0; rtsInd < 2; rtsInd++)
    		{
    			foreach (string command in modemCommands)
        		{
        			serialPort.Write(command + serialPort.NewLine);
        			retOk = false;
        			answer = "";
        			int timeout = (command == "AT") ? 10 : 20;
        		
        			// Waiting for response 1-2 sec
        			for (int i = 0; i < timeout; i++)
        			{
        				Thread.Sleep(100);
        				answer += serialPort.ReadExisting();
        				if (answer.IndexOf("OK") >= 0)
        				{
        					retOk = true;
        					break;
        				}
        			}
        		}
        		// If got responses, we found a modem
        		if (retOk)
        			return true;
    
        		// Trying to execute the commands without RTS
        		serialPort.RtsEnable = false;
        	}
    		return false;
    	}
    
