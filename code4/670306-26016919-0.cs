    //this works ONLY if the server returns 401 first
    //client DOES NOT send credentials on first request
    //ONLY after a 401
    client.Credentials = new NetworkCredential(userName, passWord); //doesnt work
    //so use THIS instead to send credenatials RIGHT AWAY
    string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + password));
    client.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
