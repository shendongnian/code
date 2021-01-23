    public ProcessFailureForm()
    {
        InitializeComponent();
    
        //Blah blah blah
    
        dtFrom.HandleCreated += delegate //if you need sender or EventArgs use: delegate(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Today.AddDays(-7);
        };
    }
