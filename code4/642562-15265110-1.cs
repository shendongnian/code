	public class ResultMapper : EntityTypeConfiguration<Result>
	{
		public ResultMapper()
		{
			HasKey(x => x.ResultId);
			Property(x => x.ResultId)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
		}
	}
