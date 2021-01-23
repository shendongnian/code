    [WebMethod]
    public string GetName(string name) 
    {
        return Product.GetLLabel(name);
    }
