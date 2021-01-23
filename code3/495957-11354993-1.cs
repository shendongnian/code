        public Form1()
        {
            InitializeComponent();
            collection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(collection_CollectionChanged);
            FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            collection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(collection_CollectionChanged);
        }
