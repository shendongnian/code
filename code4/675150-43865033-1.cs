    public View()
    {
        InitializeComponent();
        ViewModel vm = new ViewModel (); // this creates an instance of the ViewModel
        this.DataContext = vm; // this sets the newly created ViewModel as the DataContext for the View
        if (vm.CloseAction == null)
            vm.CloseAction = new Action(() => this.Close());
    }
