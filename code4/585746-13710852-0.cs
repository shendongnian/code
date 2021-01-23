    public FrmMain()
    {
        InitializeComponent();
        PrepareFormTexts();
        PrepareFormData();
        PrepareStateClass();
        Task delayTask = CheckDbConnection();
        //Initialize Data Access for AS400
        Dal = JDE8Dal.Instance;
        Dal.conString = Properties.Settings.Default.conAS400;
        //Initialize Icons
        picCon.Image = Properties.Resources.ledGreen;
        picStatus.Image = Properties.Resources.ledGreen;
        // Load recording from file if they exist
        PrepareRecordings(AppState.DataFileName,'|');
    }
