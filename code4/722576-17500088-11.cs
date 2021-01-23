    List<Product> products = new List<Product>();
    for(int i = 0; i < listS.Length; i++)
    {
        bool duplicate = false;
        foreach(Product p in products)
        {
            if(listS[i].ToLower().Equals(p.Name.ToLower()))
            {
                p.Quantity += listI[i];
                duplicate = true;
                break;
            }
        }
        if(!duplicate)
        {
            Product p;
            p.Name = listS[i];
            p.Quantity = listI[i];
            products.Add(a)
        }
    }
