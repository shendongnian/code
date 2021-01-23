    ASPXPAGE:
    <strong>Asp.Net : Delete Multiple Records form datagridview in one time<br />
            </strong>
       
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" EnableModelValidation="True" ForeColor="Black">
                <Columns>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="id" HeaderText="Sr No" />
                    <asp:BoundField DataField="doc_name" HeaderText="Name" />
                    <asp:BoundField DataField="doc_add" HeaderText="Address" />
                    <asp:BoundField DataField="doc_mob" HeaderText="Mobile No" />
                    <asp:BoundField DataField="doc_email" HeaderText="Email" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" Font-Size="12pt"
                onclick="Button1_Click1" Text="Delete" />
            <br />
        
    
    
    Code Behind Page:
    SqlConnection conn = new SqlConnection(@"server=server-pc; database=HMS; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                load_data();
            }
        }
    
       public void load_data()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from doc_master", conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
       protected void Button1_Click1(object sender, EventArgs e)
       {
           CheckBox ch;
           for (int i = 0; i < GridView1.Rows.Count; i++)
           {
               ch = (CheckBox)GridView1.Rows[i].Cells[0].Controls[1];
               if (ch.Checked == true)
               {
          int id = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
          SqlCommand cmd = new SqlCommand("delete from doc_master where ID=" + id + " ", conn);
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
               }
           }
    
           load_data();
       }
