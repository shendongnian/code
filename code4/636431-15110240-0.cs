    List<Item> unique = new List<Item>();
            string curAssetId = null; // here is the problem 
            foreach (Item result in ordered)
            {
                if (!result.ID.Equals(curAssetId)) // here you only compare the last value.
                {
                    unique.Add(result);
                    curAssetId = result.ID; // You are only assign the current ID value and 
                }
            }
