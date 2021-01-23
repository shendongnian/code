    public NewMessageWindow() {
      InitializeComponent();
      var uniqueKey = System.Guid.NewGuid().ToString();
      DataContext = SimpleIoc.Default.GetInstance<NewMessageWindowModel>();
      Closed += (sender, args) => SimpleIoc.Default.Unregister(uniqueKey);
    }
