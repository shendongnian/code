    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Data.Sql;
    using System.Data.SqlClient;
    using System.Drawing;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
    getGrid();
    
        }
        public string GetCon()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString.ToString();
        }
    
        public void getGrid()
        {
    
            GridView grd = new GridView();        
            Page.Controls.Add(grd);
            form1.Controls.Add(grd);
    
            grd.ControlStyle.Font.Size = 9;
            
    
            SqlConnection conn = new SqlConnection(GetCon());
            conn1.Open();
            SqlCommand cmd4grid = new SqlCommand("Select * from tblCustomers", conn);
            SqlDataAdapter dad = new SqlDataAdapter(cmd4grid);
            DataTable dt = new DataTable();
            dad.Fill(dt);
            grd.DataSource = dt;
            grd.DataBind();
        }
    }
    
    **strong text**
