    List<ShoppingCartDTO> shoppingList = ShoppingCart.Fetch(string.Format("WHERE SessionID='{0}'", Session["ID"]));
        Dictionary<String, Double> groups = new Dictionary<String,Double>();
        foreach (ShoppingCartDTO temp in shoppingList)
        {
            String key = String.Format("{0}-{1}", temp.CustomnerID, temp.ProductID); 
            if (groups.ContainsKey(key))
            {
               groups[key] += temp.Quantity;
            }
            else
            {
               groups.Add(key, temp.Quantity);
            }
        }
