		var installedPrinters = new string[PrinterSettings.InstalledPrinters.Count];
		PrinterSettings.InstalledPrinters.CopyTo(installedPrinters, 0);
		var printers = new List<string>();
		var printServers = new List<string>();
		var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
		foreach (var printer in searcher.Get())
		{
			var serverName = @"\\" + printer["SystemName"].ToString().TrimStart('\\');
			if (!printServers.Contains(serverName))
				printServers.Add(serverName);
		}
		foreach (var printServer in printServers)
		{
			var server = new PrintServer(printServer);
			try
			{
				var queues = server.GetPrintQueues();
				printers.AddRange(queues.Select(q => q.Name));
			}
			catch (Exception)
			{
			}
		}
		return printers.ToArray();
	}
