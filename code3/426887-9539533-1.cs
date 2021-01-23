    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            DataContext = this;
            stud = new ObservableCollection<Student>();
            stud.Add(new Student() { Name = " chauhan", RollNo = 1212, About = "dc wecwedc wec cwec wevcwe vcwd vcwvc" });
            stud.Add(new Student() { Name = " chauhan", RollNo = 1212, About = "dc wecwedc wec cwec wevcwe vcwd vcwvc" });
            stud.Add(new Student() { Name = "chauhan", RollNo = 1212, About = "dc wecwedc wec cwec wevcwe vcwd vcwvc" });
            stud.Add(new Student() { Name = " chauhan", RollNo = 1212, About = "dc wecwedc wec cwec wevcwe vcwd vcwvc" });
            stud.Add(new Student() { Name = "chauhan", RollNo = 1212, About = "dc wecwedc wec cwec wevcwe vcwd vcwvc" });
        }
        public ObservableCollection<Student> stud
        { get; set; }
        public string Text
        {
            get
            {
                return phoneNumber.Text + " - " + callResultsSelection.SelectedItem + "\r\n";
            }
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        public string About { get; set; }
    }
