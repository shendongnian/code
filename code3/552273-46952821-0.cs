    private Boolean isVersionOK()
	{
		UpdateCheckInfo info = null;
		
		if (ApplicationDeployment.IsNetworkDeployed)
		{
			ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
			
			try
			{
				info = ad.CheckForDetailedUpdate();
			}
			catch (DeploymentDownloadException)
			{
				// No network connection
				return false;
			}
			catch (InvalidDeploymentException)
			{
				return false;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
			
			if (info.UpdateAvailable)
			{
				try
				{
					ad.Update();
					Application.Restart();
					Environment.Exit(0);
				}
				catch (DeploymentDownloadException)
				{
					// No network connection
				}
				
				return false;
			}
			return true;
		}
		else
		{
			return false;
		}
	}
