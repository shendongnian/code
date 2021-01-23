    using System.Collections.Generic;
    using System.Windows;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                Student student = new Student("Joe", new List<SubjectInfo>() { new SubjectInfo("Subject1", 50), new SubjectInfo("Subject2", 70) });
                StudentGrid.DataContext = student;
            }
        }
    
        public class Student
        {
            public string Name { get; set; }
            public List<SubjectInfo> SubjectInfoList { get; set; }
    
            public Student(string name, List<SubjectInfo> list)
            {
                Name = name;
                SubjectInfoList = list;
            }
        }
    
        public class SubjectInfo
        {
            public string SubjectCode { get; set; }
            public int Marks { get; set; }
    
            public SubjectInfo(string subjectCode, int marks)
            {
                SubjectCode = subjectCode;
                Marks = marks;
            }
        }
    }
