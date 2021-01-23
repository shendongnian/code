    public MainPage()
    {
        InitializeComponent();
        AttackPerMinutesComboBox.SelectedIndex = 0;
        var targets = AutoClickManager.GetAllTargets();
        TargetListGridView.DataSource = targets;
        Bitmap search = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Search.jpg");
        ...
    }
