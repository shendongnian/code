    //**This code is tested and working fine** 
    //at aspx page
    <columns>
    <asp:TemplateField HeaderText="Checkboxes">
            <ItemTemplate>
              <asp:CheckBox ID="cheker" runat="server" />
            </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    //this button is outside gridview but in same page
    <asp:Button ID="check" runat="server" CssClass="btnstyle" Text="Check"       OnClick="btnredirect_Click" />
