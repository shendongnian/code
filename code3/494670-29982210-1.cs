    		private string UserConfigPath
		{
			get
			{
				System.Diagnostics.FileVersionInfo versionInfo;
				string strUserConfigPath, strUserConfigFolder;
				strUserConfigPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.Create);
				versionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
				strUserConfigPath = Path.Combine(strUserConfigPath, versionInfo.CompanyName, versionInfo.ProductName, versionInfo.ProductVersion, "user.config");
				strUserConfigFolder = Path.GetDirectoryName(strUserConfigPath);
				if(!Directory.Exists(strUserConfigFolder))
					Directory.CreateDirectory(strUserConfigFolder);
				return strUserConfigPath;
			}
		}
