	private void CreateUninstaller()
	{
		using (RegistryKey parent = Registry.LocalMachine.OpenSubKey(
                     @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", true))
		{
			if (parent == null)
			{
				throw new Exception("Uninstall registry key not found.");
			}
			try
			{
				RegistryKey key = null;
				try
				{
					string guidText = UninstallGuid.ToString("B");
					key = parent.OpenSubKey(guidText, true) ??
					      parent.CreateSubKey(guidText);
					if (key == null)
					{
						throw new Exception(String.Format("Unable to create uninstaller '{0}\\{1}'", UninstallRegKeyPath, guidText));
					}
					Assembly asm = GetType().Assembly;
					Version v = asm.GetName().Version;
					string exe = "\"" + asm.CodeBase.Substring(8).Replace("/", "\\\\") + "\"";
					key.SetValue("DisplayName", "My Program");
					key.SetValue("ApplicationVersion", v.ToString());
					key.SetValue("Publisher", "My Company");
					key.SetValue("DisplayIcon", exe);
					key.SetValue("DisplayVersion", v.ToString(2));
					key.SetValue("URLInfoAbout", "http://www.blinemedical.com");
					key.SetValue("Contact", "support@mycompany.com");
					key.SetValue("InstallDate", DateTime.Now.ToString("yyyyMMdd"));
					key.SetValue("UninstallString", exe + " /uninstallprompt");
				}
				finally
				{
					if (key != null)
					{
						key.Close();
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(
					"An error occurred writing uninstall information to the registry.  The service is fully installed but can only be uninstalled manually through the command line.",
					ex);
			}
		}
	}
