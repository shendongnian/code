       public partial class _Default : System.Web.UI.Page
         {
             List<string> leeg = new List<string>();
             protected void Page_Load(object sender, EventArgs e)
             {
                 LoadData();
                 
                 if (!Page.IsPostBack)
                 {
                     GridView1.DataBind();
                 }
             }
    
             private void LoadData()
             {
                 leeg.Add("");
                 leeg.Add("");
                 leeg.Add("");
                 leeg.Add("");
                 GridView1.DataSource = leeg;             
             }
    
             protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
             {
                 GridView1.EditIndex = e.NewEditIndex;
                 GridView1.DataBind();
             }
    
             protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
             {
                 e.Cancel = true;
                 GridView1.EditIndex = -1;
                 GridView1.DataBind();
             }
    
             protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
             {
                 GridViewRow row = GridView1.Rows[e.RowIndex];
    
                 TextBox txtSpoor = (TextBox)row.FindControl("txtSpoor");
    
                 e.Cancel = true;
                 GridView1.EditIndex = -1;
                 GridView1.DataBind();
             }
         } 
