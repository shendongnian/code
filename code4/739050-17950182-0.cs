    <asp:DataGrid ID="dtGrg" runat="server" AutoGenerateColumns="true" 
                                onitemcommand="dtGrg_ItemCommand">
                                <Columns>
                                    <asp:ButtonColumn HeaderText="" ButtonType="LinkButton"  Text="Graph"  CommandName="Select">
                                    </asp:ButtonColumn>
                                    <asp:ButtonColumn HeaderText="" ButtonType="LinkButton" Text="Display" CommandName="NewFunction" >
                                    </asp:ButtonColumn>
                                </Columns>
                            </asp:DataGrid>
-------------------------------------------------------------------------------------------------- 
    protected void dtGrg_ItemCommand(object source, DataGridCommandEventArgs e)
            {
                if (e.CommandName == "NewFunction")
                { 
                 //Your Code Here :
                }
                 if (e.CommandName == "Select")
                {
                    //Your Code Here :
                }
            }
