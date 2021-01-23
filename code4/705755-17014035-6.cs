    public AdventurerView()
      :this(string.Empty) {}
    
    public AdventurerView(string uniqueKey) {
      InitializeComponent();
      Messenger.Default.Register<CloseWindowMessage>(this, uniqueKey, s => Close());
    }
