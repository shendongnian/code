    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvEmployees.DataSource = new List<Employee>()
                {
                new Employee{ Id=1,Name="Employee 1"},
                new Employee{ Id=2,Name="Employee 2"}
                };
    
                gvEmployees.DataBind();
            }
        }
    }
    
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
