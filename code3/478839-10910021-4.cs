    public class TreeViewModel :ViewModelBase
        {
            private List<Department> departments;
    
            public TreeViewModel()
            {
                Departments = new List<Department>()
                {
                    new Department("Department1"),
                    new Department("Department2")
                };
            }
    
            public List<Department> Departments
            {
                get
                {
                    return departments;
                }
                set
                {
                    departments = value;
                    OnPropertyChanged("Departments");
                }
            }
        }
