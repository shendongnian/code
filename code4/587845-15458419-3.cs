    var customConfigSessionFactory = new CustomConfigSessionFactory();
    customConfigSessionFactory.PrivateKey = properties.PrivateKey;
    customConfigSessionFactory.PublicKey = properties.PublicKey;
    NGit.Transport.JschConfigSessionFactory.SetInstance(customConfigSessionFactory);
    
    var git = Git.CloneRepository()
              .SetDirectory(properties.OutputPath)
              .SetURI(properties.SourceUrlPath)
              .SetBranchesToClone(new Collection<string>() { "master" })
              .Call();
