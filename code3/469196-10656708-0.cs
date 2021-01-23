    public static void Execute()
    {
        var service = Locator.Get<ICakeService>();
        using (var db = new Cake.Model.CakeContainer())
        {
            foreach (var campaigns in service.ExportCampaigns())
            {
				ProcessCampaigns(campaigns);                
            }
        }
    }
	
	private void ProcessCampaigns(IEnumerable<Campaign>> campaigns)
	{
	    Parallel.Foreach(compaigns, ProcessCampaign);
	}
	
	private void ProcessCampaign(Campaign campaign)
	{
	    // ... logic to process a campaign ...
	}
