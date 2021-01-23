    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindData();
        }
    
        private void BindData()
        {
            if (ViewState["Employees"] == null)
            {
                List<Employee> employees = new List<Employee>
            {
                new Employee{Name="Employee 1", AllowUpdate = true},
                new Employee{Name="Employee 2", AllowUpdate = true}
            };
    
                gvEmployees.DataSource = employees;
                ViewState["Employees"] = employees;
            }
    
            else
            {
                List<Employee> employees  = ViewState["Employees"] as List<Employee>;
                gvEmployees.DataSource = employees;
            }
    
            gvEmployees.DataBind();
        }
    
        protected void Update(object sender, EventArgs e)
        {
            Button update = sender as Button;
            if (update != null & !String.IsNullOrEmpty(update.CommandArgument))
            {
                string employeeName = update.CommandArgument;
    
                List<Employee> employees = ViewState["Employees"] as List<Employee>;
                Employee emp = employees.Where(em => em.Name == employeeName).FirstOrDefault();
                emp.Name = "some new value...";
                emp.AllowUpdate = false;
    
                //Rebind the grid with the new values
                ViewState["Employees"] = employees;
                BindData();
            }
        }
    }
    
    [Serializable]
    public class Employee
    {
        public string Name { get; set; }
        public bool AllowUpdate { get; set; }
    }
