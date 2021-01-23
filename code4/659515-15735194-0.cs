    public static SuperClass GetClass(string type, string brand, string model)
    {
       SuperClass sc = (SuperClass)Activator.CreateInstance("someAssemblyName", "type");
       sc.Brand = brand;
       sc.Model = model;
       return sc;
    }
