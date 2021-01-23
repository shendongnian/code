    [XmlRoot("tileconfiguration")]
    public class TileConfiguration
    {
        [XmlElement("tile")]
        public List<Tile> Tiles { get; set; }
    }
    [XmlRoot("tile")]
    public class Tile
    {
        [XmlAttribute("top_left_x")]
        public int TopLeftX { get; set; }
        [XmlAttribute("top_left_y")]
        public int TopLeftY { get; set; }
        [XmlAttribute("bottom_right_x")]
        public int BottomRightX { get; set; }
        [XmlAttribute("bottom_right_y")]
        public int BottomRightY { get; set; }
        [XmlElement("child")]
        public List<Child> children { get; set; }
    }
    [XmlRoot("child")]
    public class Child
    {
    }
    XmlSerializer serializer = XmlSerializer(typeof(TileConfiguration));
    TileConfiguration tileConfiguration = (TileConfiguration)serializer.Deserialize(stream);
