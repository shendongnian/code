        cache.Add(new Uri(strServer), "Basic", new System.Net.NetworkCredential("username", "password","Domain"));
        cache.Add(new Uri(strServer), "Digest", new System.Net.NetworkCredential("username", "password","Domain"));    
   
        NetworkCredential  currentCredentials= cache.GetCredential(new Uri(strServer), "Basic");  //Get specific credential
        request.Credentials = currentCredentials; //Allocate credential
