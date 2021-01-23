    List<Product> reducedProduct = new List<Product>();
    for(int i = 0; i < listS.Length; i++)
    {
        bool duplicate = false;
        foreach(Product p in reducedProduct)
        {
            if(listS[i] == p.Name)
            {
                p.I += listI[i];
                duplicate = true;
                break;
            }
        }
        if(!duplicate)
        {
            Product p;
            p.Name = listS[i];
            p.I = listI[i];
            reducedProduct.Add(a)
        }
    }
