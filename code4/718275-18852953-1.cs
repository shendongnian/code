    P4.Client client = this.Repository.GetClient(clientname, null);
    string  options= "noallwrite clobber nocompress unlocked nomodtime rmdir";
    client.Options = new P4.ClientOption();
    
     if (!options.Contains("noallwrite"))
     {
         client.Options |= P4.ClientOption.AllWrite;
     }
    
     if (!options.Contains("noclobber"))
     {
        client.Options |= P4.ClientOption.Clobber;
     }
    .....
