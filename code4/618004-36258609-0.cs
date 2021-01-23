    <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="false" OnRowCommand="grd_finantial_year_RowCommand"    DataKeyNames="srno" >
        <Columns>                           
            <asp:TemplateField HeaderText="Change Status">
                <ItemTemplate>                                  
                    <asp:LinkButton ID="btnststact" Visible='<%#BtnVisibility(Eval("active").ToString(),"StatusACT")%>' Text="ACTIVATE" runat="server" CommandName="StatusACT" CommandArgument='<%#Eval("srno")%>' /> 
                </ItemTemplate>
            </asp:TemplateField>                   
        </Columns>
    </asp:GridView>
