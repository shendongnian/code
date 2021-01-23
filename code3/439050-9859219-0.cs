    public class Item
    {
      public int ItemID { get; set; }
    
      public string Name { get; set; }
    
      public int StockUnitOfMeasureId { get; set; }
      public UnitOfMeasure StockUnitOfMeasure { get; set; }
    
      public int PurchaseUnitOfMeasureId { get; set; }
      public UnitOfMeasure PurchaseUnitOfMeasure { get; set; }
    }
    class MyContext : DbContext
    {
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasRequired(x => x.StockUnitOfMeasure)
               .WithMany()
               .HasForeignKey(x => x.StockUnitOfMeasureId).WillCascadeOnDelete(true);
    
            modelBuilder.Entity<Item>().HasRequired(x => x.PurchaseUnitOfMeasure)
               .WithMany()
               .HasForeignKey(x => x.PurchaseUnitOfMeasureId).WillCascadeOnDelete(true); 
     
          base.OnModelCreating(modelBuilder);
        }
    }
