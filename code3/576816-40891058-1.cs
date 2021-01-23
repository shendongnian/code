    public class MyDbContext : DbContext
    {
        //... typical DbContext stuff
    
        public DbSet<Product> ProductSet { get; set; }
        public DbSet<Comment> CommentSet { get; set; }
    
        //... typical DbContext stuff
    
    
        public override int SaveChanges()
        {
            MonitorForAnyOrphanedCommentsAndDeleteThemIfRequired();
            return base.SaveChanges();
        }
    
        public override Task<int> SaveChangesAsync()
        {
            MonitorForAnyOrphanedCommentsAndDeleteThemIfRequired();
            return base.SaveChangesAsync();
        }
    
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            MonitorForAnyOrphanedCommentsAndDeleteThemIfRequired();
            return base.SaveChangesAsync(cancellationToken);
        }
    
        private void MonitorForAnyOrphanedCommentsAndDeleteThemIfRequired()
        {
            var orphans = ChangeTracker.Entries().Where(e =>
                e.Entity is Comment
                && (e.State == EntityState.Modified || e.State == EntityState.Added)
                && (e.Entity as Comment).ParentProduct == null);
    
            foreach (var item in orphans)
                CommentSet.Remove(item.Entity as Comment);
        }
    }
