    public static EM
    {
        public static CreditCard FindCard(this List<CreditCard> Cust, string Name)
        {
           foreach(CreditCard cust in Cust)
           {
               if(cust.Name == Name)
               {
                   return cust;
               }
           }
           return null;
        }
    }
