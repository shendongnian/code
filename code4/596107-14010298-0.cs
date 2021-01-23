        class MainWindowViewModel 
    {
        #region Constructors
        public MainWindowViewModel()
        {
            Students = new ObservableCollection<Student>();
            Students.Add(new Student("Frank", "Sinatra", 7));
            Students.Add(new Student("Bart", "Simpson", 6));
            Students.CollectionChanged += (s, e) => AverageGrade = this.GetAverageGrade();
            foreach (var student in Students)
            {
                student.PropertyChanged += OnStudentPropertyChanged;
            }
            AverageGrade = this.GetAverageGrade();
        }
        private void OnStudentPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Grade")
            {
                AverageGrade = this.GetAverageGrade();
            }
        }
        #endregion
        #region Properties
        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged("Students");
            }
        }
        private double average;
        public double AverageGrade
        {
            get
            {
                return this.average;
            }
            set
            {
                this.average = value;
                OnPropertyChanged("AverageGrade");
            }
        }
        public double GetAverageGrade()
        {
            return this.Students.Sum(s => s.Grade) / Students.Count;
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
