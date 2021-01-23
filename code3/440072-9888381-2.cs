        modelBuilder.Entity<Campaign>().HasOptional(x => x.LandingPage)
           .WithMany();
    using(var scope = new TransactionScope())
    {
    
           context.Campaigns.Add(campaign);
           context.SaveChanges();
    
           page.CampaignId = campaign.CampaignId;
           context.Pagess.Add(page);
           context.SaveChanges();
    
           scope.Complete();
    }
