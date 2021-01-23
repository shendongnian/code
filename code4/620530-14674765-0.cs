    List<int> allClients = GetClientIDs();
    
    int total = 0;
    
    const int sqlLimit = 2000;
    
    int iterations = allClients.Count() / sqlLimit;
    
    for (int i = 0; i <= iterations; i++)
    {
        List<int> tempList = allClients.Skip(i * sqlLimit).Take(sqlLimit).ToList();
    
        int thisTotal = context.Clients.Count(x => tempList.Contains(x.ClientID) && x.BirthDate != null);
    
        total = total + thisTotal;
    }
