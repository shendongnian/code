    public class Data 
    {
        public string Column1 {get;set;}
        public string Column2 {get;set;}
    }
    public partial class _Default : System.Web.UI.Page
    {
        public List<Data> data = new List<Data>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                data.Add(new Data() { Column1 = "Row 1 Col 1", Column2 = "Row 1 Col 2" });
                data.Add(new Data() { Column1 = "Row 2 Col 1", Column2 = "Row 2 Col 2" });
                data.Add(new Data() { Column1 = "Row 3 Col 1", Column2 = "Row 3 Col 2" });
                grdTeset.DataSource = data;
                grdTeset.DataBind();
            }
        }
        protected void grdTeset_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex != -1) //MAKE SURE THIS IS A DATA ROW AND NOT HEADER OR FOOTER
            {
                string value = e.Item.Cells[0].Text;
                Response.Write(value);
            }
        } 
    }
