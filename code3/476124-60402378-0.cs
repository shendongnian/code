    public class CustomerDTO
    {
        public CustomerDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    
        public readonly int     Id;
        public readonly string  Name;
        // Override Equals and GetHashCode as well...
    }
