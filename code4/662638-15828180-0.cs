    public static void UpdateProduct(ViewProduct productToUpdate)
    {
        using (var context = new my_Entities())
        {
            var BaseProduct = (from prod in context.Product
                               where prod.Ref == productToUpdate.BaseProduct.RefPrd)
                              .FirstOrDefault();
            if (BaseProduct != null)
            {
                //BaseProduct.NormeCe = false;
                BaseProduct.field1 = productToUpdate.BaseProduct.field1;
                BaseProduct.field2 = productToUpdate.BaseProduct.field2;
                //update the necesary fields
                //......
                context.SaveChanges();
            }
        }
    }
