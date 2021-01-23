        public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Students = new ObservableCollection<Student>();
            Students.Add(new Student() { Name = "abc", RollNo = 1, Course = "MCA" });
            Students.Add(new Student() { Name = "xyz", RollNo = 1, Course = "MCA" });
            Students.Add(new Student() { Name = "pqr", RollNo = 1, Course = "MCA" });
            Students.Add(new Student() { Name = "stu", RollNo = 1, Course = "MCA" });
        }
        public ObservableCollection<Student> Students { get; set; }
    }
    public  class Student
    {
        public string Name { get; set; }
        public string Course  { get; set; }
        public int RollNo { get; set; }
        public override string ToString()
        {
            return this.Name + "  " + this.Course;
        }
    }
    <ComboBox ItemsSource="{Binding Students}"/>
