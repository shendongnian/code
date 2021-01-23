    public override void FeatureActivated(SPFeatureReceiverProperties properties)
    {
        SPSite siteCollection = properties.Feature.Parent as SPSite;
        if (siteCollection != null) 
        {
            SPWeb web = siteCollection.RootWeb;
            // Rest of your code here.
        }
    }
