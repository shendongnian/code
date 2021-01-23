    public Product GetProduct(String Barcode)
    {
        string query = @"SELECT value Product FROM AzureDBEntities.Products AS Product WHERE Product.barcode = @Barcode";
        ObjectParameter parameter = new ObjectParameter("Barcode", Barcode);
        using (var context = new AzureDBEntities())
        {
            ObjectQuery<Product> results = context.CreateQuery<Product>(query, parameter);
            foreach (Product result in results)
            {
                if (result != null)
                {
                    context.Detach(result);
                    return result;
                }
            }
        }
        return null;
    }
