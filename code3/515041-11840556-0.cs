    public interface IUnitOfWork {
        public void Commit();
    }
    public class DataContext : IUnitOfWork {
        public void Commit() {
            this.SaveChanges();
        }
    }
    public class SalesPeopleRepository {
        private DataContext _db
        public SalesPeopleRepository(IUnitOfWork uow) {
            _db= uow as DataContext;
        }
        public IEnumerable<SalesPerson> GetAllSalesPeople() { 
            return _db.SalesPeople.ToList();
        }
    }
    // Usage:
    using (var uow as new DataContext()) {
        var salesPeople = new SalesPeopleRepository(uow);
        // ...
        uow.Commit(); // If changes must be committed back to the database
    }
