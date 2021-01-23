    <div>
    <asp:CheckBox ID="chkSelectAll" runat="server" />
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" oncheckedchanged="chkSelect_CheckedChanged" AutoPostBack="true" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            bool isFound = false;
                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    CheckBox chkSelect = gvr.FindControl("chkSelect") as CheckBox;
                    if (chkSelect.Checked == false)
                    {
                        isFound = true;
                        break;
                    }
                    
                }
                if (isFound)
                {
                    chkSelectAll.Checked = false;
                }
                else
                {
                    chkSelectAll.Checked = true;
                }
        }
