    public class Student
    {
        public int Age { get; set; }
        public double GPA { get; set; }
        public string Name { get; set; }
    }
    public Form1()
    {
            InitializeComponent();
            Student[] arrStudents = new Student[1];
            arrStudents[0] = new Student();
            arrStudents[0].Age = 8;
            arrStudents[0].GPA = 3.5;
            arrStudents[0].Name = "Bob";
            dataGridView1.DataSource = arrStudents;
    }
