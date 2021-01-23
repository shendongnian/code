    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace WebApplication1
    {
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                SqlConnection conn = new SqlConnection("Password=password;Persist Security Info=True;User ID=uid;Initial Catalog=Northwind;Data Source=servername");
                SqlCommand cmd = new SqlCommand("select top 10 * from orders", conn);
                cmd.Connection.Open();
                var dt = cmd.ExecuteReader();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                cmd.Connection.Close();
                cmd.Dispose();
            }
            
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateChildGrid")
            {
                
                GridViewRow row = (e.CommandSource as Button).NamingContainer as GridViewRow;
                GridView child = row.FindControl("GridView2") as GridView;
                string id = row.Cells[0].Text;
                SqlConnection conn = new SqlConnection("Password=password;Persist Security Info=True;User ID=uid;Initial Catalog=Northwind;Data Source=servername");
                SqlCommand cmd = new SqlCommand("select top 5 * from [order Details] where OrderID = " + id, conn);
                cmd.Connection.Open();
                var dt = cmd.ExecuteReader();
                child.DataSource = dt;
                child.DataBind();
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string id = e.Row.Cells[0].Text;
                GridView gv = new GridView();
                gv = (GridView)e.Row.FindControl("GridView2");
                SqlConnection conn = new SqlConnection("Password=password;Persist Security Info=True;User ID=uid;Initial Catalog=Northwind;Data Source=servername");
                SqlCommand cmd = new SqlCommand("select top 5 * from [order Details] where OrderID = " + id, conn);
                cmd.Connection.Open();
                var dt = cmd.ExecuteReader();
                gv.DataSource = dt;
                gv.DataBind();
                cmd.Connection.Close();
                cmd.Dispose();
            }
            
            
        } 
    }
