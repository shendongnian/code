    public MainPage()
    {
        InitializeComponent();
        this.BindingValidationError += MainPage_BindingValidationError;
    }
    private void MainPage_BindingValidationError(object sender, ValidationErrorEventArgs e)
    {
    	var state = e.Action == ValidationErrorEventAction.Added ? "Invalid" : "Valid";
    
    	VisualStateManager.GoToState((Control)e.OriginalSource, state, false);
    }
