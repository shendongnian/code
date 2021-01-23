    public Student objectOfStudent { get; set; }
    
    public MainWindow()
    {
        InitializeComponent();
        objectOfStudent = new Student();
        objectOfStudent.StudentName = "John diley";
        objectOfStudent.Address = "20, North Travilia, Washington DC.";
        //not setting datacontext here since i set that in xaml
     }
