    public MainPage()
    {
      this.InitializeComponent();
      NoteViewModel nvm = new NoteViewModel();
      this.DataContext = nvm;
    }
