    protected void Test(object sender,DataGridEventArgs e) 
    { 
       if(e.CommandName == "GridView1_RowDeleting")
       {
           // do something
       }
    }
                              
    asp:GridView ID="GridView1"
                 runat="server"
                 OnItemCommand="Test"
                 AllowPaging="True">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton  ID="img1"
                                      runat="server"
                                      CommandName="GridView1_RowDeleting"
                                      ImageUrl="~/Images/cross.png" />
                   
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
