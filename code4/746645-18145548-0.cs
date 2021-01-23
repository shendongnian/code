     protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
    
                modelBuilder.Entity<Message>()
                            .HasRequired(a => a.Sender)
                            .WithMany()
                            .HasForeignKey(u => u.Sender).WillCascadeOnDelete(false);
    
                modelBuilder.Entity<Message>()
                .HasRequired(a => a.Recipient)
                .WithMany()
                .HasForeignKey(u => u.Recipient).WillCascadeOnDelete(false);
            }
