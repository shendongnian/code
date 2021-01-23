    public class BusinessEntity
    {
        public string FirstName { get; set; } // Instead of NameFirst
        public string LastName { get; set; }
        public Book Bk { get; set; } // Bk instead of BookDetails
        public string Salary { get; set; }
    }
    public class Book
    {
        public string Name { get; set; } // No prefixes
        public int Price { get; set; }
        public string Description { get; set; }
    }
