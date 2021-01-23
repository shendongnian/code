    if (ServerUtilities.IsValidToRun(ServerFeatures.FancyFeatureRequiredVersion))
    {
        ...
    }
    	
	public static class ServerFeatures
	{
		public static Version FancyFeatureRequiredVersion
		{
			get { return new Version(2, 1, 3); }
		}
	}
