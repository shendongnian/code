    public static void UpdateProduct(ViewProduct productToUpdate)
        {
            using (var contexte = new my_Entities())
            {
                var BaseProduct = (from prod in contexte.Product
                                   where prod.Ref == productToUpdate.BaseProduct.RefPrd
                                          select new ViewBaseProduct
                                          {
                                              RefPrd = prod.Ref,
                                              DescrPrd = prod.DescrPrd,
                                              NormeCe = (bool)prod.NormeCE
                                          }).FirstOrDefault();
    
                if (BaseProduct != null)
                {
                    BaseProduct.BaseProduct.RefPrd=productToUpdate.BaseProduct.RefPrd
                    BaseProduct.BaseProduct.DescrPrd=productToUpdate.BaseProduct.DescrPrd
                    BaseProduct.BaseProduct.NormeCE==(bool)productToUpdate.BaseProduct.NormeCE
                    contexte.SaveChanges();
                }
            }
    }
