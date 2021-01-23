        abstract class GenericCollection<T> : IGenericCollection<T>
        {
            public IEnumerable<T> Items { get; set; }
        }
        class ConcreteCollection : GenericCollection<string>
        {
            
        }
        static void Main(string[] args)
        {
           // will constraint fail here ?
           CollectionOwner<int,ConcreteCollection> o = new  CollectionOwner(int, ConcreteCollection);
        }
        
