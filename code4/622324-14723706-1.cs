	public partial class _Default : System.Web.UI.Page
	{
		Employee emp;
		
		protected void Page_Load(object sender, EventArgs e)
		{
			emp = new Employee();
			emp.SetEmployeeID(001);
			emp.SetEmployeeSalary(5000);
			emp.EmployeeName = "Rob";
			emp.EmployeeAge = 26;
		
			showBtn.Click += new EventHandler(showBtn_Click);
		}
		
		void showBtn_Click(object sender, EventArgs e)
		{
			HttpContext.Current.Response.Write(emp.ToString());
		}
	}
