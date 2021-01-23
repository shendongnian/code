    using FFInfo.DAL.Tables;
    using System.Data.Entity;
    namespace FFInfo.DAL
    {
        public class SiteNavigation : Base<SiteNavigation>
        {
            public DbSet<Navigation> Navigation { get; set; }
            public DbSet<Section> Sections { get; set; }
            public DbSet<Locale_Section> SectionTranslations { get; set; }
        }
    }
