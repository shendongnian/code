        this.Property(e => e.FromAnothertable).HasColumnName("AnotherTableColumn");
        this.Map(m =>
            {
                m.Properties(e =>
                     {
                         e.Id,
                         e.Name
                     });
                     m.Property(e => e.Id).HasColumnName("ThePrimaryKeyId");
                     m.Property(e => e.Name).HasColumnName("MyDatabaseName");
                   m.Property(e => e.Id).HasColumnName("ThePrimaryKeyId");
                m.ToTable("MainTable");
            });
        this.Map(m =>
            {
                m.Properties(e =>
                     {
                         e.Id,
                         e.FromAnotherTable
                     });
                m.ToTable("ExtendedTable");
            });
}
