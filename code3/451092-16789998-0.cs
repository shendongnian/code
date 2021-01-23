    <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" 
        onrowcommand="GridView_RowCommand" onrowdatabound="GridView_RowDataBound">
        <Columns>
             <asp:TemplateField HeaderText="Change Status" ItemStyle-CssClass="GrdItemImg">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtnChangeActiveStatus" CommandArgument='<%#Eval("RecordID")%>'
                                        CommandName='GRDSTATUS' runat="server" ImageUrl='<%# getStatusImage(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"IsApproved"))) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
            <asp:BoundField DataField="Col2" HeaderText="Col2" />
             //Other Respective  columns....
                    ...........
                    ..........
        </Columns>
    </asp:GridView>
