	foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
	{
		var ps = new PrinterSettings { PrinterName = installedPrinter };
		var maxResolution = ps.PrinterResolutions.Cast<PrinterResolution>().OrderByDescending(pr => pr.X).First();
		Console.WriteLine("{0}: {1}x{2}", installedPrinter, maxResolution.X, maxResolution.Y);
	}
