    private void SetAddRemoveProgramsIcon()
    {
    	if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun)
    	{
    		try
    		{
    			var iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "MyIcon.ico");
    
    			if (!File.Exists(iconSourcePath)) return;
    
    			var myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
    			if (myUninstallKey == null) return;
    
    			var mySubKeyNames = myUninstallKey.GetSubKeyNames();
    			foreach (var subkeyName in mySubKeyNames)
    			{
    				var myKey = myUninstallKey.OpenSubKey(subkeyName, true);
    				var myValue = myKey.GetValue("DisplayName");
    				if (myValue != null && myValue.ToString() == "MyProductName") // same as in 'Product name:' field
    				{
    						myKey.SetValue("DisplayIcon", iconSourcePath);
    					break;
    				}
    			}
    		}
    		catch (Exception uhoh)
    		{
    			//log exception
    		}
    	}
    }
