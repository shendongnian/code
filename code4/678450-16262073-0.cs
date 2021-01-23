    		try
			{
				// Create object to monitor the printer queue
				PrintServer printServer = new PrintServer(serverPath);
				mPrintQueue = printServer.GetPrintQueue(printerName);
			}
			catch (PrintServerException ex)
			{
				// If the problem might be creating the server because the name is an alias
				if (ex.Message.Contains("printer name is invalid."))
				{
					string actualServerHostname = "\\\\" + Dns.GetHostEntry(serverPath.TrimStart('\\')).HostName;
					// Create object to monitor the printer queue
					PrintServer printServer = new PrintServer(actualServerHostname);
					mPrintQueue = printServer.GetPrintQueue(printerName);
					// Write to log about the use of a different address
				}
				else
				{
					throw;
				}
			}
