        public Form1()
        {
            InitializeComponent();
            collection.CollectionChanged += new NotifyCollectionChangedEventHandler(collection_CollectionChanged);
        }
