    public override void FeatureActivated(SPFeatureReceiverProperties properties)
    {
        SPWeb web = properties.Feature.Parent as SPWeb;  
        //Some code with web
    }
