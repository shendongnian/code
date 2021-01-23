      // aspx code
        <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
       // code behind In the Page_Load event of your page, write the below code
      string connection = "Connection string";
        string query = "SELECT DISTINCT ID,Name FROM Master"; // 
        SqlConnection con = new SqlConnection(connection);
        SqlCommand cmd = new SqlCommand();     
        cmd.CommandText = query;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        con.Open();
        
        DataTable dt=cmd.ExecuteNonQuery();
        DropDownList1.DataTextField = "Name";
        DropDownList1.DataValueField = "ID";
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
 
