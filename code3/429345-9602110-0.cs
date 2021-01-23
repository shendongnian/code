    public class Convolutions {
        private readonly List<Convolution> items = new List<Convolution>();
        [XmlElement("Convolution")]
        public List<Convolution> Items { get { return items; } }
    }
