    public class ApplicationConfiguration : EntityTypeConfiguration<Application>
    {
        public ClientConfiguration()
        {
            ToTable("SpecialApplication");
        }
    }
