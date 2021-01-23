    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                    </ItemTemplate>                   
                </asp:TemplateField>
            </Columns>            
        </asp:GridView>
        // and bind this grid view in the Page_Load of my Page
        protected void Page_Load(object sender, EventArgs e)
        { 
        DataTable dt = new DataTable();
        dt.Columns.Add("name");
        DataRow row = dt.NewRow();
        row[0] = "Waqar Janjua";
        dt.Rows.Add(row);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        }
        // When I view this page in the browser it shows "Waqar Janjua"
        // Now to update the columns text, I add the following code and it works.
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
            Label l = new Label();
            l = (Label)e.Row.FindControl("Label1");
            l.Text = "waqar";           
          }
        }
       // When I run this page now, it shows me "Waqar" not "Waqar Janjua" The code works for me.
 
