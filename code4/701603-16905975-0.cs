        foreach (KeyValuePair<string, int> e in errorOrders)
                {
    
                   errPercentage = GetErrPercentage(e.Key);
                   Console.WriteLine("Percentage of errors for " + e.Key + ": " + Math.Round(errPercentage, 2) * 100 + "%");
                   ordersPerHour = OrdersPerHour(e.Key);
                   RandomOrders = RandomSelect(errPercentage, e.Key);
    
    }
    
    
    Console.WriteLine("Number of orders pulled : " + RandomOrders.Rows.Count);
                    //Print out orders randomly collected
                    for (int i = 0; i < RandomOrders.Rows.Count; i++)
                    {
                        Console.WriteLine(RandomOrders.Rows[i]["ControlNumber"]);
                    }
    
                    Console.WriteLine("\r\n");
    
    static double GetErrPercentage(string user)
            {
                double errPercentage = 0;
                
                errPercentage = (double)errorOrders[user]/ (double)totalOrders[user];          
                return errPercentage;
            }
