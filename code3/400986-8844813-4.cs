public class MyContext : DbContext
{
    public DbSet< Throne> Thrones { get; set; }
    public DbSet< King> Kings { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {    
        //We define the key for the King table
        modelBuilder.Entity< King>().HasRequired(x => x.Throne);
    }
}
</pre>
