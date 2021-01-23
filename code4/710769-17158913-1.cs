    public MainWindow()
    {
        InitializeComponent();
        MaxRows = 100;
        Translations = new ReactiveCollection<string>();
        LoadDataCommand = new ReactiveAsyncCommand();
        LoadDataCommand.RegisterAsyncFunction(_ => LoadData())
            .Subscribe(items => 
            {
                foreach(var i in items) Translations.Add(i);
            })
        LoadDataCommand.ThrownExceptions.Subscribe(ex => 
        {
            Console.WriteLine("Oh crap: {0}", ex);
        })
        InitializeComponent();
        this.DataContext = this;
    }
    private List<int> LoadData()
    {
        // TODO: Return the list of stuff you want to add
        return Enumerable.Range(0, maxRows).ToList();
    }
