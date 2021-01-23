    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {     
        modelBuilder.Entity<Event>()
           .HasOptional(ev => ev.WinningEntry)
           .WithMany()
           .HasForeignKey(ev => ev.WinningEntryId)
           .WillCascadeOnDelete(false);
        modelBuilder.Entity<Entry>()
            .HasRequired(en => en.Event)
            .WithMany(ev => ev.Entries)
            .HasForeignKey(en => en.EventId);
    }
    
