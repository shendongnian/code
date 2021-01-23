        public BrowserMode()
        {
            InitializeComponent();
            this.Loaded += BroswerMode_Loaded;
        }
        void BrowserMode_Loaded(object sender, EventArgs e)
        {
            if (webBrowser1.Source != null
             && webBrowser1.Source.Scheme == "http")
            {
                qd = new QuestionData();
                // ...
            }
        }
