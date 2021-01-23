    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void RadGrid1_Init(object sender, EventArgs e)
    {
        DefineGridStructure();
    }
    private void DefineGridStructure()
    {
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "EmpId" };
        RadGrid1.Width = Unit.Percentage(98);
        RadGrid1.PageSize = 5;
        RadGrid1.AllowPaging = true;
        RadGrid1.AllowSorting = true;
        RadGrid1.PagerStyle.Mode = GridPagerMode.NextPrevAndNumeric;
        RadGrid1.AutoGenerateColumns = false;
        RadGrid1.ShowStatusBar = true;
        RadGrid1.MasterTableView.PageSize = 5;
        //Add columns
        GridBoundColumn boundColumn;
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "EmpId";
        boundColumn.HeaderText = "EmpId";
        RadGrid1.MasterTableView.Columns.Add(boundColumn);
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "Name";
        boundColumn.HeaderText = "Name";
        RadGrid1.MasterTableView.Columns.Add(boundColumn);
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "Age";
        boundColumn.HeaderText = "Age";
        RadGrid1.MasterTableView.Columns.Add(boundColumn);
        //Detail table - Orders (II in hierarchy level)
        GridTableView tableViewOrders = new GridTableView(RadGrid1);
        tableViewOrders.Width = Unit.Percentage(100);
        tableViewOrders.DataKeyNames = new string[] { "EmpId" };
        GridRelationFields relationFields = new GridRelationFields();
        relationFields.MasterKeyField = "EmpId";
        relationFields.DetailKeyField = "EmpId";
        tableViewOrders.ParentTableRelation.Add(relationFields);
        RadGrid1.MasterTableView.DetailTables.Add(tableViewOrders);
        //Add columns
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "Street";
        boundColumn.HeaderText = "Street";
        tableViewOrders.Columns.Add(boundColumn);
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "City";
        boundColumn.HeaderText = "City";
        tableViewOrders.Columns.Add(boundColumn);
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "Zip";
        boundColumn.HeaderText = "Zip";
        tableViewOrders.Columns.Add(boundColumn);
        
        //New Detail Table #2 - adds in a another class that stores data
        GridTableView tableViewOrders2 = new GridTableView(RadGrid1);
        tableViewOrders2.Width = Unit.Percentage(100);
        tableViewOrders2.DataKeyNames = new string[] { "EmpId" };
        GridRelationFields relationFields2 = new GridRelationFields();
        relationFields2.MasterKeyField = "EmpId";
        relationFields2.DetailKeyField = "EmpId";
        tableViewOrders2.ParentTableRelation.Add(relationFields2);
        RadGrid1.MasterTableView.DetailTables.Add(tableViewOrders2);
        //Add columns
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "HobbyName";
        boundColumn.HeaderText = "HobbyName";
        tableViewOrders2.Columns.Add(boundColumn);
         
    }
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        List<Employee> empList = GetEmployeeDetails();
        DataSet dataset = new DataSet("DataSet");
        System.Data.DataTable dt1 = new System.Data.DataTable();
        dt1.TableName = "Employee";
        dt1.Columns.Add("EmpId");
        dt1.Columns.Add("Name");
        dt1.Columns.Add("Age");
        dataset.Tables.Add(dt1);
        System.Data.DataTable dt2 = new System.Data.DataTable();
        dt2.TableName = "Address";
        dt2.Columns.Add("EmpId");
        dt2.Columns.Add("Street");
        dt2.Columns.Add("City");
        dt2.Columns.Add("Zip");
        dataset.Tables.Add(dt2);
        
        //New datatable that stores the new classes' data
        DataTable dt3 = new DataTable();
        dt3.TableName = "Hobby";
        dt3.Columns.Add("EmpId");
        dt3.Columns.Add("HobbyName");
        dataset.Tables.Add(dt3);
         
        foreach (Employee emp in empList)
        {
            dt1.Rows.Add(new object[] { emp.EmpId, emp.Name, emp.Age });
            foreach (Address add in emp.Address)
            {
                dt2.Rows.Add(new object[] { emp.EmpId, add.Street, add.City, add.Zip });
            }
            //New data add loop
            foreach (Hobby hob in emp.Hobby)
            {
                dt3.Rows.Add(new object[] { emp.EmpId, hob.HobbyName });
            }
             
        }
        RadGrid1.MasterTableView.DataSource = dataset.Tables["Employee"];
        RadGrid1.MasterTableView.DetailTables[0].DataSource = dataset.Tables["Address"];
        //Add the new table to the grid
        RadGrid1.MasterTableView.DetailTables[1].DataSource = dataset.Tables["Hobby"];
    }
    private List<Employee> GetEmployeeDetails()
    {
        List<Employee> myEmployees = new List<Employee>();
        Employee Steve = new Employee()
        {
            Address = new List<Address>() { new Address { City = "op", Street = "thatstreet", Zip = 23312 } },
            Hobby = new List<Hobby>() { new Hobby() { HobbyName = "Skating" } },
            Age = 23,
            EmpId = "Emp1",
            Name = "SteveIsTheName"
        };
        Employee Carol = new Employee()
        {
            Address = new List<Address>() {
                        new Address { City = "op2", Street = "thatstreet2", Zip = 23313 },
                        new Address { City = "op3", Street = "thatstreet3", Zip = 23314 }},
            Hobby = new List<Hobby>() { new Hobby() { HobbyName = "Fishing" } },
            Age = 24,
            EmpId = "Emp2",
            Name = "CarolIsTheName"
        };
        myEmployees.Add(Steve);
        myEmployees.Add(Carol);
        return myEmployees;
    }
    }
    class Employee
    {
        public List<Address> Address { get; set; }
    
        public List<Hobby> Hobby { get; set; }
    
        public int Age { get; set; }
    
        public string Name { get; set; }
    
        public string EmpId { get; set; }
    }
    
    class Address
    {
        public string Street { get; set; }
    
        public string City { get; set; }
    
        public int Zip { get; set; }
    }
    
    class Hobby
    {
        public string HobbyName { get; set; }
    }
