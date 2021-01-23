    public interface IMyFileIO
    {
        public byte[] ReadFromFile(int bytes); // whatever
    }
    
    public static IEnumerable<Customer> GetStuff(IMyFileIO file, int filterValue)
    {
    }
