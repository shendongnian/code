    public MainWindow()
        {
            InitializeComponent();
            //The view model object
            ViewModel vm = new ViewModel();
            vm.CandidateValue = "1";
            this.DataContext = vm;
            //create data trigger object for TextBox
            DataTrigger d = new DataTrigger();
           
            //create binding object for data trigger
            Binding b = new Binding("Text");
            ValueConverter c = new ValueConverter();
            b.Converter = c;
            //create binding object for ValueConverter.CandidateValueProperty
            Binding convertBinding = new Binding("CandidateValue");
            convertBinding.Source = vm;
            BindingOperations.SetBinding(c, ValueConverter.CandidateValueProperty, convertBinding);
            
            d.Binding = b;
            d.Value = true;
            Setter s = new Setter(TextBox.ForegroundProperty, Brushes.Red);
            d.Setters.Add(s);
            Style st = new Style(typeof(TextBox));
            st.Triggers.Add(d);
            this.TextBox.Style = st;
        }
