    using (RegistryKey ExcelLocation = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Office\Excel\Addins"))
			foreach (string subKeyName in ExcelLocation.GetSubKeyNames())
			{
				// Open the key.
				using (RegistryKey subKey = ExcelLocation.OpenSubKey(subKeyName))
				{
					// Write the value.
					Console.Writeline(subKey.GetValue("Description"));
					Console.Writeline(subKey.GetValue("FriendlyName"));
					Console.Writeline(subKey.GetValue("Manifest"));
				}
			}
