    public class Tile
    {
        [Key, Column(Order=1)]
        public int X { get; set; }
        [Key, Column(Order=2)]
        public int Y { get; set; }
        public string AdditionalField1 { get ;set; }
        ...
    }
