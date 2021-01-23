    public class IndexerClass
    {
        public MyIndexedProperty IndexProperty { get; set; }
        public IndexerClass()
        {
            IndexProperty = new MyIndexedProperty();
            IndexProperty[3, 4] = 12;
        }
    }
