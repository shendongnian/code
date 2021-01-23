    public class Item
    {
        ...
        [ForeignKey("Manufacturer")]
        public int? ManufacturerID { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
    public class Manufacturer
    {
        ...
        public virtual List<Item> Items { get; set; }
    }
