    [WebMethod]
    public  string[][]  GetAllItemsArray() 
    {
            FoodCityData.ShoppingBuddyEntities fdContext = new FoodCityData.ShoppingBuddyEntities();
    
            IQueryable<Item> Query =
           from c in fdContext.Item
           select c;
    
            List<Item> AllfNames = Query.ToList();
            int arrayZise = AllfNames.Count;
            String[][] xx = new String[arrayZise][2]; //change here
            int i = 0;
            int j = 0;
            foreach(Item x in AllfNames)
            {
    
                    xx[i][0] = x.ItemName.ToString();
                    xx[i][1] = x.ItemPrice.ToString();
                    i++;
            }
    
             return xx;
     }
