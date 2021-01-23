    public override int SaveChanges() {
      foreach (var item in this.ChangeTracker.Entries().Where(x=> x.EntityState == EntityState.Deleted)){
        var entity = item.Entity as IVirtualDelete;
        if(entity != null){
          entity.Deleted = true;
          item.EntityState = EntityState.Modified;
        }
      }
      return base.SaveChanges();
    }
