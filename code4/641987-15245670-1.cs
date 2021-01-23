        Type t = typeof(Product);
        PropertyInfo[] proInfo = t.GetProperties().Where( p => p.Name != "ProdId" && p.Name != "Description").ToArray() ;
         
        foreach (var item in proInfo)
        {
            Console.WriteLine(item.Name);
        }
