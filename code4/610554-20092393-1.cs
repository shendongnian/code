    try
    {
        //your code here
    }
    catch (System.ServiceModel.FaultException<SalesOrderDelete.SalesOrderDeleteTcpNet.AifFault> aifFaults) // This code catches error messages even when "Logging mode = Logging is disabled" on Inbound port
    {
        SalesOrderDelete.SalesOrderDeleteTcpNet.InfologMessage[] infologMessageList = aifFaults.Detail.InfologMessageList;
    
        foreach (SalesOrderDelete.SalesOrderDeleteTcpNet.InfologMessage infologMessage in infologMessageList)
        {
            
            Console.WriteLine("Exception: " + infologMessage.Message + "\n");
        }
        
        Console.WriteLine("\nPress any key to quit.\n");
        Console.ReadKey();
        cl.Abort();
    }
