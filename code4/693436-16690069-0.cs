    public class TransactionConfig : EntityTypeConfiguration<Transaction>
    {
        public TransactionConfig ()
        {
            this.HasMany(t => t.Products)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("TransactionId");
                    x.MapRightKey("ProductId");
                    x.ToTable("TransactionProducts");
                });
        }
    }
