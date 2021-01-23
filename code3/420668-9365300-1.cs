    public class County
    {
        public short? ID { get; private set; }
        public string Name { get; private set; }
        private Country(short? id,string name)
        {
          ID=id;
          Name=name;
        }
    }
