    string address;
    for (int i = 0; i < clientSection.Endpoints.Count; i++)
    {
        if (clientSection.Endpoints[i].Name == "SecService")
            address = s.Endpoints[i].Address.ToString();
    }
