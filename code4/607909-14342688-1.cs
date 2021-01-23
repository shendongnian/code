    public partial class UserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvEmployees.DataSource = new List<Employee>
                {
                    new Employee{Name="Employee 1"},
                    new Employee{Name="Employee 2"},
                    new Employee{Name="Employee 3"},
                    new Employee{Name="Employee 4"},
                    new Employee{Name="Employee 5"},
                    new Employee{Name="Employee 6"},
                    new Employee{Name="Employee 7"},
                };
                gvEmployees.DataBind();
            }
        }
    }
    
    public class Employee
    {
        public string Name { get; set; }
    }
