    public class SalesRepository : BaseRepository<Sales>
    {
        public override IEnumerable<Sales> GetAll()
        {
            return GetAll(null);
        }
        public IEnumerable<Sales> GetAll(IEnumerable<Customer> Customers)
        {
            return null;
        }
    }
    BaseRepository<Sales> rep = new SalesRepository();
    rep.GetAll();
