    public class Customer
        {
            private double[] totalPurchasesLastThreeDays; 
    
            public string CustomerName { get; set; }
    
            public double[] TotalPurchasesLastThreeDays
            {
                get
                {
                    return totalPurchasesLastThreeDays;
                }
                set
                {
                    totalPurchasesLastThreeDays = value;
                }
            }
        }
