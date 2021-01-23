    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
                ToDoItems = new ObservableCollection<TodoItem>(new List<TodoItem>
                    {
                        new TodoItem("Content1"),
                        new TodoItem("Content2")
                    });
            this.DataContext = this;
        }
        public ObservableCollection<TodoItem> ToDoItems { get; set; }
    }
