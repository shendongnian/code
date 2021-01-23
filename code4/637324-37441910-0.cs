    public class Workload
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public WorkloadStatus Status {get; set; }
        public Configruation Configuration { get; set; }
    }
    public class Configuration
    {
        public int Timeout { get; set; }
        public bool SaveResults { get; set; }
        public int UnmappedProperty { get; set; }
    }
    
    public class WorkloadMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Workload>
    {
        public WorkloadMap()
        {
             ToTable("Workload");
             HasKey(x => x.Id);
        }
    }
    // Here This is where we mange the Configuration
    public class ConfigurationMap : ComplexTypeConfiguration<Configuration>
    {
        ConfigurationMap()
        {
           Property(x => x.TimeOut).HasColumnName("TimeOut");
           Ignore(x => x.UnmappedProperty);
        }
    }
