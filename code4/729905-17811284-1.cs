    public override int SaveChanges()
        {
          if (string.IsNullOrEmpty(this.Database.Connection.ConnectionString))
            this.Database.Connection.ConnectionString = savedConnectionString;
          return base.SaveChanges();
        }
