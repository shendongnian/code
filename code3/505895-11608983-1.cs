    using (var client = new HttpClient())
    {
        client.TransportSettings.Credentials = new System.Net.NetworkCredential("username", "pwd");
        ...
    }
