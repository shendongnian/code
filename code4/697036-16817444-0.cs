     WebClient webClient = new WebClient();
     var credCache = new CredentialCache();
     credCache.Add(new Uri(url), "Negotiate", 
         new NetworkCredential(serviceUserName, servicePassword, serviceDomainName));
     webClient.Credentials = credCache;
     webClient.DownloadFile(url,Path);
