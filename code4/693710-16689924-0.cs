        static void ParseSupplierIdWithProducts()
        {
            string supplierIdWithProducts = "1_1001,1_1002,20_1003,100_1005,100_1006";
            //eg. [0] = "1_1001", [1] = "1_1002", etc
            List<string> supplierIdAndProductsListSeparatedByUnderscore = supplierIdWithProducts.Split(',').ToList();
            //this will be the placeholder for each product ID with multiple products in them
            //eg. [0] = key:"1", value(s):["1001", "1002"]
            //    [1] = key:"20", value(s):["1003"]
            Dictionary<string, List<string>> supplierIdWithProductsDict = new Dictionary<string, List<string>>();
            foreach (string s in supplierIdAndProductsListSeparatedByUnderscore)
            {
                string key = s.Split('_')[0];
                string value = s.Split('_')[1];
                List<string> val = null;
                //look if the supplier ID is present
                if (supplierIdWithProductsDict.TryGetValue(key, out val))
                {
                    if (val == null)
                    {
                        //the supplier ID is present but the values are null
                        supplierIdWithProductsDict[key] = new List<string> { value };
                    }
                    else
                    {
                        supplierIdWithProductsDict[key].Add(value);
                    }
                }
                else
                {
                    //that supplier ID is not present, add it and the value/product
                    supplierIdWithProductsDict.Add(key, new List<string> { value });
                }
            }
        }
