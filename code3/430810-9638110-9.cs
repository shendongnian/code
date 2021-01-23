    public ObservableCollection<Question> Questions { get; private set; }
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        Questions = new ObservableCollection<Question>();
    
        for (int i = 1; i <= 10; i++)
        {
            var newQ = new Question { QuestionText = "intrebarea " + i.ToString(), QuestionImage = _get your image as a ImageSource here_ };
            Questions.Add(newQ);
        }
    }
