    public class MyGroup
    {
        public string Name { get; set; }
    
        private IList children = new CompositeCollection() {
                    new CollectionContainer { Collection = new List<MyGroup>() },
                    new CollectionContainer { Collection = new List<TestItem>() }
        };
    
        public IList Children
        {
            get { return children; }
            set { children = value; }
        }
    
        public MyGroup(string name)
        {
            Name = name;
        }
    }
