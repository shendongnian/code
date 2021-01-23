           namespace Data.Context
            {
                // Table
                internal partial class MyTableConfiguration : EntityTypeConfiguration<MyTable>
                {
                    public MyTableConfiguration(string schema = "dbo")
                    {    
                        ToTable(schema + ".MyTable");
                        HasKey(x => x.Id);
            
                        Property(x => x.ColumnName).HasColumnName("ColumnName").IsOptional().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
                        ....
