    [XmlRoot("TextureAtlas", IsNullable = false)]
    public class TextureAtlasXml
    {
        public static TextureAtlasXml FromFile(String file)
        {
            using (var stream = File.OpenRead(file))
            {
                return FromStream(stream);
            }
        }
        public static TextureAtlasXml FromStream(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(TextureAtlasXml));
            return (TextureAtlasXml)serializer.Deserialize(stream);
        }
        [XmlAttribute("imagePath")]
        public String ImagePath;
        [XmlAttribute("width")]
        public Int32 Width;
        [XmlAttribute("height")]
        public Int32 Height;
        [XmlElement("sprite")]
        public List<SpriteXml> Sprites;
    }
    public class SpriteXml
    {
        [XmlAttribute("n")]
        public String Name;
        [XmlAttribute("x")]
        public Int32 X;
        [XmlAttribute("y")]
        public Int32 Y;
        [XmlAttribute("w")]
        public Int32 Width;
        [XmlAttribute("h")]
        public Int32 Height;
        public Rectangle Rectangle { get { return new Rectangle(this.X, this.Y, this.Width, this.Height); } }
    }
