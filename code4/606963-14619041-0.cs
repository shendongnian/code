     public HomePage()
        {
            InitializeComponent();
            String AppId = SResources.Ad_App_ID;
            String AdUnitID = SResources.Ad_Unit_ID;
            sAdControl.AdUnitId = AdUnitID;
            sAdControl.ApplicationId = AppId;
            sAdControl.Width = 480;
            sAdControl.Height = 80;
            sAdControl.ErrorOccurred += new EventHandler<Microsoft.Advertising.AdErrorEventArgs>(sAdControl_ErrorOccurred);
        }
        void sAdControl_ErrorOccurred(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {
               string error=e.Error.ToString();
        }
