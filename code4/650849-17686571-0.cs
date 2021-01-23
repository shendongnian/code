	public class MyEntityMap : EntityTypeConfiguration<MyEntity>
	{
		public MyEntityMap ()
		{
			HasKey(t => t.MyId);
			Property(t => t.MyId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			ToTable("MyEntity", "MySchema");
		}
	}
