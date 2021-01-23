    foreach(PopulationClient pClients in populationClients)
    {
         if(!InTempList(clients, pClients.ID) && !InTempList(temp_list, pClients.ID))
         {
             temp_list.Add(client);
         }
    }
