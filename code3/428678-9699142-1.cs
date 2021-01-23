    using (ServerManager serverManager = ServerManager.OpenRemote(server))
    {
      Site site = serverManager.Sites.Where(s => s.Name == websiteName).Single();
      foreach (Binding binding in site.Bindings)
         certHash += BitConverter.ToString(binding.CertificateHash).Replace("-", string.Empty);                    
    }
