    public class MyDataEntity
    {
        public DateTime? MyDate { get; set; }
        public IDictionary<Identifier, decimal?> IdentifierType { get; set; } 
    }
    public enum Identifer
    {
        Toyota,
        Honda,
        Nissan,
        Mazda
    }
