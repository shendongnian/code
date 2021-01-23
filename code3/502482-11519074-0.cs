        public void SearchProducts()  
        {  
            //Filter by search string array(searchArray)  
            List<string> prodId = new List<string>();
            StoreProductCollection prod = new StoreProductCollection();  
            prod.Query.Where(searchArray.Contains(prod.Query.StptName.ToLower()) && prod.Query.StptDeleted.IsNull());  
            prod.Query.Select(prod.Query.StptName, prod.Query.StptPrice, prod.Query.StptImage, prod.Query.StptStoreProductID);  
            //  prod.Query.es.Top = 4;  
            prod.Query.Load();  
  
            if (prod.Count > 0)  
            {  
                foreach (StoreProduct stpt in prod)  
                {  
                    if (!prodId.Contains(stpt.StptStoreProductID.ToString().Trim()))  
                    {  
                        prodId.Add(stpt.StptStoreProductID.ToString().Trim());  
                        productObjectsList.Add(stpt);  
                    }  
  
                }  
            }  
         }  
