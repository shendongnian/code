        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine(ResxLocalizationProvider.GetDefaultDictionary(this));
            ResxLocalizationProvider.SetDefaultDictionary(this, "OtherStrings");
            Console.WriteLine(ResxLocalizationProvider.GetDefaultDictionary(this));
        }
    
