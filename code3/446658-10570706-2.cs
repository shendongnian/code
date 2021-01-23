    public void SaveNewProduct(string code)
    {
       var prod = new Product() { Code = code };
       var contextSerializer = new ContextSerialzer();
       contextSerializer.SaveProduct(prod);
    }
   
