    SkyfilterClient c = client as SkyfilterClient;
    if (c != null)
    {
        //do something with it
    }
     
    NetworkClient c = new SkyfilterClient() as NetworkClient; // c is not null
    SkyfilterClient c2 = new NetworkClient() as SkyfilterClient; // c2 is null
