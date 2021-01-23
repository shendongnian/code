    using Microsoft.Web.Administration
    ...
    using(var manager = new ServerManager())
    {
        // variables are set in advance...
        var site = manager.Sites.Add(siteName, siteFolder, siteConfig.Port);
        var store = new X509Store(StoreName.AuthRoot, StoreLocation.LocalMachine);
        store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadWrite);
        // certHash is my certificate's hash, byte[]
        var binding = site.Bindings.Add("*:443:", certHash, store.Name);
        binding.Protocol = "https";
        store.Close();
        site.ApplicationDefaults.EnabledProtocols = "http,https";
  
        manager.CommitChanges();
    }
