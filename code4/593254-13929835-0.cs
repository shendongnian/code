    using System.Data.Entity;
    namespace Application.Models
    {
        public class Entities : DbContext
        {
            public DbSet<MyEntityClass> MyEntityClass { get; set; }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<System.Web.Services.Protocols.SoapHeader>();
        }
    }
