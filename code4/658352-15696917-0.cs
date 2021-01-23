        public override int SaveChanges()
        {
          if(currentUserIsNotAnAdmin){
          var entries= ObjectStateManager.GetObjectStateEntries(EntityState.Added |   
       EntityState.Modified).OfType<Product>() ;
            foreach(entry in entries){//or throw an error here
              this.Entry(entry).State=System.Data.EntityState.Unchanged
            }
          }
            return base.SaveChanges();
        }
