     context.Products.Attach(product);
                context.ObjectStateManager.ChangeObjectState(product, System.Data.EntityState.Modified);
                context.ObjectStateManager.ChangeObjectState(product.ProductDescription, System.Data.EntityState.Modified);
                context.ObjectStateManager.ChangeObjectState(product.ProductModel, System.Data.EntityState.Modified);
                context.SaveChanges();
