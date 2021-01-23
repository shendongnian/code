    public class Section
        {
            public string Name { get; set; }
            public int Capacity { get; set; }
            public int MinimumStaffing { get; set; }
            public int IdealStaffing { get; set; }
            public Section(string name, List<Person> employee)
            {
                this.Name = name;
                this._Employee = employee;
            }
            public Section()
            {
                this._Employee = new List<Person>(); //if you call the empty constructor, create the list
            }
            private List<Person> _Employee; 
            public List<Person> Employee
            {
                get
                {
                    return this._Employee;
                }
                set
                {
                    this._Employee = value;
                }
            }
        }
