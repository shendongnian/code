    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="Sql_dalei" DataTextField="name1" DataValueField="flag1" AutoPostBack="True" OnSelectedIndexChanged="zhonglei_SelectedIndexChanged"></asp:DropDownList>
    
    <asp:SqlDataSource ID="Sql_dalei" runat="server" 
    ConnectionString="<%$ ConnectionStrings:SignBoardConnectionString%>"
    SelectCommand="SELECT * FROM [TestCodeClass1]"></asp:SqlDataSource>
                
    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="Sql_zhonglei" DataTextField="name2" DataValueField="flag2" AutoPostBack="True" OnSelectedIndexChanged="nmnm_SelectedIndexChanged">
    </asp:DropDownList>
    
    <asp:SqlDataSource ID="Sql_zhonglei" runat="server"
     ConnectionString="<%$ ConnectionStrings:SignBoardConnectionString %>"
    SelectCommand="SELECT * FROM [TestCodeClass2]"></asp:SqlDataSource>
    
    ----------------------------------------------------------------------------
    
     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem { Text = "大類名稱", Value = "0" });
                DropDownList1.SelectedItem.Selected = true;
                tet.Attributes["class"] = "s2";
            }
        }
    
    protected void zhonglei_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex != 0)
            {
                DropDownList2.Items.Clear();
                String s = DropDownList2.SelectedValue;
                Sql_zhonglei.SelectCommand = "SELECT * FROM [TestCodeClass2] where preflag1='" + DropDownList1.SelectedIndex + "'";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem { Text = "中類名稱", Value = "0" });
                tett.Attributes["class"] = "s2";
                tett2.Attributes["class"] = "s";
                if (DropDownList2.SelectedValue == "")
                {
                    tett.Attributes["class"] = "s";
                    
    
                }
    
            }
            else
            {
                tett.Attributes["class"] = "s";
                tett2.Attributes["class"] = "s";
            }
    
        }
