    class User {     
    
     public Int32 ID {get;set;}  
    
     public virtual ICollection<UserCityDetail> {get;set;}
    
     public int? MainCityUserID {get;set;}
     public int? MainCityID {get;set;}
     public UserCityDetail MainCityDetail {get;set;}
    
    }
    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasOptional(u => u.MainCityDetail)
                .WithMany()
                .HasForeignKey(u => new { u.MainCityUserID, u.MainCityID})
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Cities)
                .WithRequired(d => d.User)
                .HasForeignKey(d => d.UserId);
        }
    }
