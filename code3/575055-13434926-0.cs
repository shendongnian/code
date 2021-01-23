    public class ContentRepository: DbContext
    {
        public DbSet<Content_Template> content_Templates { get; set; }
        public DbSet<Master_Template> master_Templates { get; set; }
        public DbSet<Master_Content_Map> master_Content_Maps { get; set; }
        public ContentRepository()
            : base("name=MessagingSystemEntities")
        {
        }
