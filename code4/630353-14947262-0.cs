    public class Employee : PropertyChangedBase
    {
        private string empName;
  
        private string surname;
        public string EmpName 
        { 
           get { return this.empName; }
           set { this.empName = value; this.NotifyOfPropertyChange(() => this.EmpName); }
        }
        
        public string Surname 
        { 
           get { return this.surname; }
           set { this.surname = value; this.NotifyOfPropertyChange(() => this.Surname); }
        }
    }
