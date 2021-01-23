     public mainForm()
        {
            InitializeComponent();
            IgnoreList = new SortedSet<string>();
            IgnoreQueue = new IgnoreListQueue(); //no new declaration, this will set the public IgnoreListQueue you define later.
        }
