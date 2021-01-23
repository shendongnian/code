    // in the class of the view: MyView
    public string ViewModelString // the property which stays in sync with VM's property
    {
        get { return (string)GetValue(ViewModelStringProperty); }
        set
        {
            var oldValue = (string) GetValue(ViewModelStringProperty);
            if (oldValue != value) SetValue(ViewModelStringProperty, value);
        }
    }
    public static readonly DependencyProperty ViewModelStringProperty =
        DependencyProperty.Register(
            "ViewModelString",
            typeof(string),
            typeof(MyView),
            new PropertyMetadata(OnStringValueChanged)
            );
    private static void OnStringValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
        // do some custom stuff, if needed
        // if not, just pass null instead of a delegate
    }    
    public MyView()
    {
        InitializeComponent();
        // this is the binding, which binds the property of the VM to your dep. property
        // my convention is give my property wrapper in the view the same name as the property in the VM has
        var nameOfPropertyInVm = "ViewModelString"
        var binding = new Binding(nameOfPropertyInVm) { Mode = BindingMode.TwoWay };
        this.SetBinding(SearchStringProperty, binding);
    }
