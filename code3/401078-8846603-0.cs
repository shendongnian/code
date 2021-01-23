    private void BindGrid()
    {
       SPLinqDataContext dc = new SPLinqDataContext(SPContext.Current.Web.Url);
       EntityList<EmployeesItem> Employees = dc.GetList<EmployeesItem>("Employees");
       var EmployeeQuery = from e in Employees.ToList() //Point 1
                           select new                   //Point 2
                           {
                               Title = e.Title,
                               FirstName = e.FirstName,
                               Position = e.Position.Title,
                               PositionDescription = e.Position.Description,
                               Department = e.Position.Department.Title
                           };
       GridView1.DataSource = EmployeeQuery;            //Point 3
       GridView1.DataBind();
