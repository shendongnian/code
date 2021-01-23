    this.Map(m =>
        {
			m.Property(p => p.Id).HasColumnName("NotTheSameName");
            m.Properties(e =>
                 {
                     e.Id,
                     e.FromAnotherTable
                 });
            m.ToTable("ExtendedTable");
        });
