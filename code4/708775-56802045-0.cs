    var parameters = new Dictionary<string, string>()
    {
        { "ham", "Glaced?" },
        { "x-men", "Wolverine + Logan" },
        { "Time", DateTime.UtcNow.ToString() },
    }; 
    var query = new FormDataCollection(parameters).ReadAsNameValueCollection().ToString();
