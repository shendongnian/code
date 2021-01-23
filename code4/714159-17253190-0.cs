        public Media()
        {
            
            RefreshMediaList();
            DarkTheme = Global.Configuration.IsDarkModeAppliedAsTheme();
            InitializeComponent(); // <-- Here
        }
