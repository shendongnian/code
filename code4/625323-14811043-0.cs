    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    namespace EF_DEMO
    {
    class FK121
    {
        public static void ENTRYfk121(string[] args)
        {
            var ctx = new Context121();
            ctx.Database.Create();
            System.Console.ReadKey();
        }
    }
    public class Candidate
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]// best in Fluent API, In my opinion..
        public long CandidateId { get; set; }
     //   public long CandidateDataId { get; set; }// DONT TRY THIS... Although DB will support EF cant deal with 1:1 and both as FKs
        public virtual CandidateData Data { get; set; }  // Reverse navigation
    
    }
    public class CandidateData 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] // best in Fluent API as it is EF/DB related 
        public long CandidateDataId { get; set; }   // is also a Foreign with EF and 1:1 when this is dependent
       // [Required]
       // public long CandidateId { get; set; }   // dont need this... PK is the FK to Principal in 1:1
       public virtual Candidate Candidate { get; set; } // yes we need this
    }
    public class Context121 : DbContext
    {
        static Context121()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context121>());
        }
        public Context121()
            : base("Name=Demo") { }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateData> CandidateDatas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>();
                            
            modelBuilder.Entity<CandidateData>()
                        .HasRequired(q => q.Candidate)
                        .WithOptional(p=>p.Data) // this would be blank if reverse validation wasnt used, but here it is used
                        .Map(t => t.MapKey("CandidateId"));    // Only use MAP when the Foreign Key Attributes NOT annotated as attributes
        }
    }
}
