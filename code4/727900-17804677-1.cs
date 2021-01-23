    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                GridView1.DataBind();
        }
        public List<myData> GetData(string param)
        {
            List<myData> lst = new List<myData>();
            lst.Add(new myData() { Name = "Hello", Code = "World", PictureURL = "Images/Select.png" });
            return lst;
        }
        public string pageRequested
        {
            get {
                return Page.Request.QueryString["SearchScreen"];
            }
        }
        protected void Grd_RowDatabound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink lnkNavigate = (HyperLink)e.Row.FindControl("lnkNavigate");
                if (lnkNavigate != null)
                {
                    myData obj = (myData)e.Row.DataItem;
                    lnkNavigate.NavigateUrl = pageRequested + ".aspx?ProductCode="+obj.Code;
                }
            }
        }
    }
    public class myData
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string PictureURL { get; set; }
    }
