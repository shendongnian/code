    class ProductListPresenter {
        
        private void DeleteHandler(Object sender, EventArgs e)
        {
           productRepo.SaveChanges();
           productRepo.DetachLogicallyDeletedEntities();
        }
    }
    class ProductRepository 
    {
      public void DetachLogicallyDeletedEntities()
      {
       foreach(var entity in _context.Products.Local
               .Where(p=>p.Deleted == 1).ToList())
                   _context.Entry(entity).State = EntityState.Detached;
       }
    }
