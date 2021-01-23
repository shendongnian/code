    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    
    namespace StackOverflow11087468
    {
        public class ViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<Student> Students { get; set; }
    
            public ViewModel()
            {
                this.Students = new ObservableCollection<Student>();
                Students.Add(new Student(98760987, "Student1", "F"));
                Students.Add(new Student(98760988, "Student22", "M"));
            }
    
            public Student SelectedStudent
            {
                get { return _selectedStudent; }
                set
                {
                    _selectedStudent = value;
                    RaisePropertyChanged("SelectedStudent");
                }
            }
    
            private void RaisePropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private Student _selectedStudent;
        }
    }
