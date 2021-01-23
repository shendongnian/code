    //from the dotnetspeak solution (copy existing headers)
    foreach (var httpRequestHeader in controllerContext.Request.Headers)
    {
        client.DefaultRequestHeaders.Add(httpRequestHeader.Key, httpRequestHeader.Value);
    }
    //Set basic authentication, whatever the original Authorization header might have been
    //TODO: use lookup table or something like that to convert claimsPrinciple to matching domain user account 
    var byteArray = Encoding.ASCII.GetBytes(@"Domain\userId:password");
    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                
