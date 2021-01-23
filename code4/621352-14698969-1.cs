    public EmployeeListing(string firstname, string lastname, string gender, int age, int years, string title, string exempt, int salary)
        {
                InitializeComponent();
                //employeeList.Rows.Add(firstname, lastname, gender, age, years, title, exempt, salary);                      
                DataTable dtSource = new DataTable();
                dtSource.Columns.Add("firstname", typeof(string));
                dtSource.Columns.Add("lastname", typeof(string));
                dtSource.Columns.Add("gender", typeof(string));
                dtSource.Columns.Add("age", typeof(string));
                dtSource.Columns.Add("years", typeof(string));
                dtSource.Columns.Add("title", typeof(string));
                dtSource.Columns.Add("exempt", typeof(string));
                dtSource.Columns.Add("salary", typeof(string));
                DataRow dtRow;
    
                dtRow = dtSource.NewRow();
                dtRow[0] = firstname;
                dtRow[1] = lastname;
                dtRow[2] = gender;
                dtRow[3] = age;
                dtRow[4] = years;
                dtRow[5] = Title;
                dtRow[6] = exempt;
                dtRow[7] = salary;
    
                dtSource.Rows.Add(dtRow.ItemArray);
                employeeList.DataSource = dtSource;
        }
