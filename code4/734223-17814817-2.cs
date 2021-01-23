    public interface IMyContext {
        IDbSet<Car> Cars { get; }
    }
    public class MyContext : DbContext, IMyContext {
        IDbSet<Car> IMyContext.Cars {
            get { return Cars; }
        }
        public DbSet<Car> Cars { get; set; }
    }
