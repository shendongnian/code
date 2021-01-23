    public List<Advertiser> GetAdvertisers()
    {
        return CampaignManagementService.GetAdvertisers((string) Session["ticket"]).ToList();
    }
    
    public List<Campaign> GetCampaigns(IEnumerable<Advertiser> advertisers)
    {
        return advertisers.Select(a => CampaignManagementService.GetCampaigns((string)Session["ticket"],
                                       Convert.ToInt32(a.Key))).ToList();
    }
