    public string[] GetList(String theType)
        {
            ArrayList theList = new ArrayList();
            foreach (Product p in products)
            {
                if (p.GetType().ToString() == theType)
                    theList.Add(p.ProductName);
            }
            return theList.Cast<string>().ToArray();
        }
