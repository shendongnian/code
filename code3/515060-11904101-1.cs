    public class MyHolder
    {
        public MyHolder()
        {
            Objects = new List<object>();
        }
        public string Name { get; set; }
        [TypeConverter(typeof(MyCollectionConverter))]
        public List<object> Objects { get; private set; }
    }
