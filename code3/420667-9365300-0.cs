    public class County
    {
        public short? ID { get; private set; }
        public string Name { get; private set; }
        public Country(short? id,string name)
        {
          ID=id;
          Name=name;
        }
    }
