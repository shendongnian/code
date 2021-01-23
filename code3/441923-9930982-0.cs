    <script type="text/javascript">
        valueChanged = function(rowIndex){
            __doPostBack("<%= GridView1.ClientID %>", rowIndex);
        }
    </script>
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="ID" ...>
        <Columns>
            <asp:TemplateField>
                <asp:TextBox ID="TextBox1" runat="server" onchange='valueChanged(<%# Container.ItemIndex %>);' />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>    
