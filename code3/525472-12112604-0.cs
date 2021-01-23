    Client.EMPServiceClient proxy = new Client.EMPServiceClient(); 
    
    proxy.ClientCredentials.UserName.UserName = "testuser"; 
    proxy.ClientCredentials.UserName.Password = "password"; 
    
    Client.EMPSearchCriteria criteria = new Client.EMPSearchCriteria(); 
    criteria.EMPNumber = "01-351"; 
    var data =    proxy.GetEMPData(criteria); // Change this line
    
    SerializeToXML(data); // and adding this line
    
    Console.Write("Finish"); 
