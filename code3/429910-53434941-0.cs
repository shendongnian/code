    public QuoteConfiguration(string schema)
    {
        ToTable("Quote", schema);
        HasKey(x => x.ID);
        Property(x => x.ID).HasColumnName(@"ID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        Property(x => x.QuoteNumber).HasColumnName(@"Quote_Number").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(64).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
    }
