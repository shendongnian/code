    public partial class Index : System.Web.UI.Page
    {
        StudentRepository sr = new StudentRepository();
        List<StudentClass> sc = new List<StudentClass>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Student.rdlc");
                sc = sr.GetStudents();
                IEnumerable<StudentClass> ie;
                ie = sc.AsQueryable();
                ReportDataSource datasource = new ReportDataSource("DataSet1", ie);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
        }
    }
