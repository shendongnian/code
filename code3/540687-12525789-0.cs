    public class NewsItemConfiguration : EntityTypeConfiguration<NewsItem> {
        public NewsItemConfiguration() {
            HasRequired(n => n.Author).WithMany();
            HasRequired(n => n.LastEditor).WithMany();
        }
    }
