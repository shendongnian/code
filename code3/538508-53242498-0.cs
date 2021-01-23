    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
        .
        .
        .
        public System.Data.Entity.DbSet<Solution.Models.Model1> Model1 { get; set; }
        //Comment out possible Model and try debugging again.
        //public System.Data.Entity.DbSet<Solution.Models.Model2> Model2 { get; set; }
}
