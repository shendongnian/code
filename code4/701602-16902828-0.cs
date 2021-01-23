    foreach (KeyValuePair<string, int> error in errorOrders)
    {
    	if (totalOrder.HasKey(error.Key) {
    		var total = totalOrders[error.Key];
    		
    		errPercentage = ((double)error.Value / (double)total);                        
            Console.WriteLine("Percentage of errors for " + error.Key + ": " + Math.Round(errPercentage, 2) * 100 + "%");
            ordersPerHour = OrdersPerHour(error.Key);
            RandomOrders = RandomSelect(errPercentage, error.Key);
    
    
            Console.WriteLine("Number of orders pulled : " + RandomOrders.Rows.Count);
            //Print out orders randomly collected
            for (int i = 0; i < RandomOrders.Rows.Count; i++) 
            {
                Console.WriteLine(RandomOrders.Rows[i]["ControlNumber"]);
            }
    
            Console.WriteLine("\r\n");
            //NumOrdersToPull = FindNumOrdersToPull(Math.Round(errPercentage,2), ordersPerHour);
    	}
    }
