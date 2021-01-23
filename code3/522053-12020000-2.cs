    private readonly User _model;
    public Form1(User model)
    {
        _model = model;
        InitializeComponent();
    }
    public event CreateUserHandler Create; // should be changed to use User 
    //Function to create a new record into the DB
    private void btnSave_click(object sender, System.EventArgs e)
    {
        // if model is not bound via binding, it needs update before Create.
        Create(_model); // needs changes to current EventHandler
    }
