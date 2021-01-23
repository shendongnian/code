    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="BasicGridView" %>
    
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
    
    <html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Untitled Page</title>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        
        </div>
        </form>
    </body>
    </html>
    
    File: Default.aspx.cs
    
    
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
    using System.Web.Configuration;
    using System.Data.SqlClient;
    
    public partial class BasicGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
                string selectSQL = "SELECT ProductID, ProductName, UnitPrice FROM Products";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(selectSQL, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
    
                adapter.Fill(ds, "Products");
    
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
    }
    
    
    File: Web.config
    
    <?xml version="1.0"?>
    <configuration>
      <connectionStrings>
        <add name="Northwind" connectionString="Data Source=localhost\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI"/>
      </connectionStrings>
    </configuration>
