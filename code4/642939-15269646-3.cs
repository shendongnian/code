    private MovieViewModel vm;
    public MyWindow()
    {
       InitializeComponent();
       vm = new MovieViewModel();
       this.DataContext = vm;
    }
