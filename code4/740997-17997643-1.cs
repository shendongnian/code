    public class ViewModel:INotifyPropertyChanged
        {
            public ViewModel() 
            {
                StudentList1 = new ObservableCollection<Student>();
                StudentList1.Add(new Student() { Name = "abc", Age = 20 });
                StudentList1.Add(new Student() { Name = "abc", Age = 20 });
                StudentList1.Add(new Student() { Name = "abc", Age = 20 });
                StudentList2 = new ObservableCollection<Student>();
                StudentList2.Add(new Student() { Name = "xyz", Age = 30 });
                StudentList2.Add(new Student() { Name = "xyz", Age = 30 });
                StudentList2.Add(new Student() { Name = "xyz", Age = 30 });
            }
            public ObservableCollection<Student> StudentList1 { get; set; }
            public ObservableCollection<Student> StudentList2 { get; set; }
            Student selectedStudent;
            public Student SelectedStudent
            {
                get { return selectedStudent; }
                set { selectedStudent = value; Notify("SelectedStudent"); }
            }
            public void Notify(string propName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
            
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
