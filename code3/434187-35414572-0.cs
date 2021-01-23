		private bool GetIfXPSPrinterIsInstalled()
		{
            bool isXPSPrinterMissing = true;
			try
			{				
				var printerQuery = new System.Management.ManagementObjectSearcher("SELECT * from Win32_Printer");
				var iterator = printerQuery.Get().GetEnumerator();
				while (iterator.MoveNext() && isXPSPrinterMissing )
				{
					isXPSPrinterMissing = iterator.Current.GetPropertyValue("DriverName").ToString() != "Microsoft XPS Document Writer";
				}
				if (isXPSPrinterMissing )
				{
					MessageBox.Show("Warning, there is no XPS printer installed on this computer");
				}
			}
			catch (Exception ex)
			{
                MessageBox.Show("System couldn't verify if there is a XPS printer installed because an error occured");				
			}
            return !isXPSPrinterMissing;
		}
