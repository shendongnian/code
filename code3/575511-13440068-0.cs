    public  abstract class BosBaseObject
    {
      public virtual Guid Id { set; get; }
      public virtual string ExternalKey { set; get; }
      public byte[] RowVersion { get; set; }
    }
	 public abstract class BosObjectDateManaged   :  BosBaseObject
    {
        public DateTimeOffset ValidFrom { set; get; }
        public DateTimeOffset ValidTo { set; get; }
    }
	public class News : BosObjectDateManaged
    {
        public String Heading { set; get; }
    }
	
	
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var conf = new BosBaseEntityConfiguration<News>();//Construct config for Type
            modelBuilder.Configurations.Add( conf );  // this has base mapping now
            var newsConf = new NewsConfiguration(conf); // now the Object specific properties stuff
        
        }
    }
    public class BosBaseEntityConfiguration<T> : EntityTypeConfiguration<T> where T : BosBaseObject
    {
       public BosBaseEntityConfiguration()
       {
           // Primary Key
           this.HasKey(t => t.Id);
           //// Properties
           this.Property(t => t.Id).HasDatabaseGeneratedOption(databaseGeneratedOption: DatabaseGeneratedOption.None);
           this.Property(t => t.RowVersion)
               .IsRequired()
               .IsFixedLength()
               .HasMaxLength(8)
               .IsRowVersion();
           //Column Mappings
           this.Property(t => t.Id).HasColumnName("Id");
       }
    }
	 public class NewsConfiguration  
    {
        public  NewsConfiguration(BosBaseEntityConfiguration<News> entity)
        {
            // Table Specific & Column Mappings
            entity.ToTable("News2");
            entity.Property(t => t.Heading).HasColumnName("Heading2");
        }
    }
