    protected override void OnModelCreating(DbModelBuilder modelbuilder)
    {
        modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();
        
        // Example of controlling TPH iheritance:
        modelBuilder.Entity<PaymentComponent>()
                .Map<GiftPaymentComponent>(m => m.Requires("MyType").HasValue("G"))
                .Map<ClubPaymentComponent>(m => m.Requires("MyType").HasValue("C"));
       
        // Example of controlling Foreign key:
        modelBuilder.Entity<Payment>()
                    .HasMany(p => p.PaymentComponents)
                    .WithRequired()
                    .Map(m => m.MapKey("PaymentId"));
    }
