    //BEWARE
    //This works ONLY if the server returns 401 first
    //The client DOES NOT send credentials on first request
    //ONLY after a 401
    client.Credentials = new NetworkCredential(userName, passWord); //doesnt work
    //So use THIS instead to send credentials RIGHT AWAY
    string credentials = Convert.ToBase64String(
        Encoding.ASCII.GetBytes(userName + ":" + password));
    client.Headers[HttpRequestHeader.Authorization] = string.Format(
        "Basic {0}", credentials);
