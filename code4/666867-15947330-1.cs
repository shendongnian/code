    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var items = new List<License> { new License { Agreement = "Agreement 1" }, new License { Agreement = "Agreement 2" } };
                grid.DataSource = items;
                grid.DataBind();
            }
        }
    
        protected void Accept(object sender, EventArgs e)
        {
        }
    
        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                (e.Row.FindControl("btnAccept") as Button).Enabled = false;
        }
    
        protected void CheckedChanged(object sender, EventArgs e)
        {
            var chkAgreement = sender as CheckBox;
            Button btnAccept = null;
    
            if (chkAgreement != null)
            {
                var row = chkAgreement.Parent.Parent as GridViewRow;
                btnAccept = row.FindControl("btnAccept") as Button;
    
                if (btnAccept != null)
                    if (chkAgreement.Checked)
                        btnAccept.Enabled = true;
                    else
                        btnAccept.Enabled = false;
            }
        }
    }
    
    public class License
    {
        public string Agreement { get; set; }
    }
