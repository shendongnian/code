    public static void Execute(Action<campaign[]> action)
    {
        var service = Locator.Get<ICakeService>();
        using (var db = new Cake.Model.CakeContainer())
        {
            Parallel.Foreach(service.ExportCampaigns(), action);
        }
    }
    
    //This method will be executed in parallel for each element in the IEnumerable<campaign[]>.
    private void ProcessCampaigns(campaign[] campaigns)
    {
        foreach (var campaign in campaigns)
        {
            // ... logic to process a campaign ...
        }
    }
    // Call to Execute looks something like this:
    command.Execute(ProcessCampaigns)
