    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    namespace StackOverflow
    {
        public abstract class AbstractService
        {
            public int Id { get; set; }
            public virtual Site Site { get; set; }
            public int SiteId { get; set; }
        }
        [Table("StudyTeamServices")]
        public class StudyTeamService : AbstractService
        {
            public virtual Role Role { get; set; }
        }
        public class Role
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public abstract class AbstractSite
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Site : AbstractSite
        {
            public virtual ICollection<AbstractService> StudyTeamServices { get; set; }
        }
        public class Context : DbContext
        {
            static Context()
            {
                Database.SetInitializer<Context>(null);
            }
            public DbSet<AbstractService> AbstractServices { get; set; }
            public DbSet<StudyTeamService> StudyTeamServices { get; set; }
            public DbSet<Site> Sites { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                //Not EdmMetadata Table on DB
                //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
                modelBuilder.Configurations.Add(new AbstractServiceMap());
            }
        }
        public class AbstractServiceMap : EntityTypeConfiguration<AbstractService>
        {
            public AbstractServiceMap()
            {
                HasRequired(a => a.Site).WithMany(s => s.StudyTeamServices).HasForeignKey(a => a.SiteId);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var context = new Context();
                context.Database.Delete();
                context.Database.Create();
                var studyTeamService = new StudyTeamService();
                studyTeamService.Role = new Role { Name = "role1" };
                studyTeamService.Site = new Site { Name = "Site1" };
                context.StudyTeamServices.Add(studyTeamService);
                context.SaveChanges();
                Console.WriteLine("Done");
                Console.ReadLine();
            }
        }
    }
