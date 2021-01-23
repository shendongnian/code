    public List<String> GetList(string theType)
        {
            List<String> TheList = new List<String>();
            
                foreach (Product p in products)
                {
                    if (p.Type = theType))
                    {
                        theList.add(ProductName); 
                    }
                }
            
            return theList;
        }
