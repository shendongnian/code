    <asp:TemplateField HeaderText="Is Active?">
                    <ItemTemplate>
                          <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("IsActive") %>' ></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="isActive" runat="server" 
                                      AutoPostBack="true" OnCheckedChanged="isActive_OnCheckedChanged"
                                      Checked='<%# Convert.ToBoolean(Eval("IsActive")) %>'
                                      Text='<%# Eval("IsActive").ToString().Equals("True") ? " Active " : " Inactive " %>'/>
                    </EditItemTemplate>
                </asp:TemplateField>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // here you will select the IsActive column and modify it's text
            Label isActive=new Label();
            isActive = (Label) e.row.FindControl("lblIsActive");
            // after getting the reference set its text
            isActive.Text="Active or InActive";            
        }
    }
