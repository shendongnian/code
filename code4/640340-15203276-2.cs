    public class MyNiceTableName
        {
            public string User { get; set; }
        }
    
        internal class MyNiceTableNameMap : EntityTypeConfiguration<MyNiceTableName>
        {
            public MyNiceTableNameMap()
            {
                ToTable("SomeHorribleTableName");
                Property(p => p.User).IsRequired().HasColumnName("Usr");
            }
        }
