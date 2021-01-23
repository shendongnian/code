    public class MyClass : IDisposable
    {
        PhoneBookDataContext db;
  
        public MyClass()
        {
            db = new PhoneBookDataContext();
        }
        public IQueryable<PhoneNumber> GetPhoneDirectory()
        {
            return db.PhoneNumbers.Where(d => d.Site == _site);
        }
        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }
    }
    // Caller
    using(var myClass = new MyClass())
    {
        var queryable = myClass.GetPhoneDirectory();
        ...
    }
