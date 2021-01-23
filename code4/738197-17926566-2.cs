    <asp:GridView ID="GridView1" runat="server" 
      AutoGenerateColumns="false" GridLines="None" Width="100%">
        <Columns>
            ...
            <asp:TemplateField HeaderText="Approved/Denied">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td><asp:CheckBox ID="CheckBox1" ... /></td>
                            <td><asp:CheckBox ID="CheckBox2" ... /></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
