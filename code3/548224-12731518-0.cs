    public class SomeClass
    {
        private readonly IRepository _repo;
        public SomeClass(IRepository repo)
        {
            _repo = repo;
        }
    
        public void SomeMethod(StreamReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // put your logic and use the _repo to update your database.
            }
        }
    }
