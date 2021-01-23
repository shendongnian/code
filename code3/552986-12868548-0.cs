    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class Answer : BaseEntity
    {
        public String Answers { get; set; }
        public String Division { get; set; }
        public String Phone { get; set; }
        public String Description { get; set; }
    }
    public class DB_Context : DbContext
    {
        .....
        public override int SaveChanges()
        {
            var changeSet = ChangeTracker.Entries<BaseEntity>();
            if (changeSet != null)
            {
                foreach (var added in changeSet.Where(x => x.State == System.Data.EntityState.Added))
                {
                    added.Entity.CreatedDate = DateTime.UtcNow;
                    added.Entity.ModifiedDate = DateTime.UtcNow;
                }
                foreach (var modified in changeSet.Where(x => x.State == System.Data.EntityState.Modified))
                {
                    modified.Entity.ModifiedDate = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }
    }
