    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var employees = new List<Employee>{new Employee{Id="1",Name="Employee 1"}};
                gvEmployees.DataSource = employees;
                gvEmployees.DataBind();
            }
        }
    }
    
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
