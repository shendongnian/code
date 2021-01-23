    public class Image
    {
        private readonly byte[] data;
        private readonly string name;
        public string Name { get { return name; } }
        public Image(string name, byte[] data)
        {
            this.name = name;
            this.data = data;
        }
        public Stream GetDataStream()
        {
            return new MemoryStream(data, false);
        }
    }
