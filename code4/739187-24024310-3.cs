    [Bind(Exclude = "ID")]
    public class Item
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        public String Name { get; set; }
        public byte[] InternalImage { get; set; } //Stored as byte array in the database.
    }
