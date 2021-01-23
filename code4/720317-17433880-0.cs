     <asp:DataGrid   ID="dgCaseStatusTypes" 
                        runat="server" 
                        AutoGenerateColumns="False" 
                        CellPadding="5"
                        DataKeyField="InmateCaseStatusID" 
                        OnItemCommand="dgCaseStatusTypes_ItemCommand">
        <Columns>
            <asp:TemplateColumn HeaderText="ID Label" Visible="false">
                <ItemTemplate>
                    <asp:Label  id="IDLabel" 
                                runat="server" 
                                AutoPostBack="true" 
                                Text='<%# Eval("InmateCaseStatusID") %>' 
                                ></asp:Label>
                 </ItemTemplate>
            </asp:TemplateColumn>
    
            <asp:BoundColumn DataField="Code" HeaderText="Code"></asp:BoundColumn>
            <asp:BoundColumn DataField="Text" HeaderText="Text"></asp:BoundColumn>
            
            <asp:TemplateColumn HeaderText="Prebook Visible" >
                <ItemTemplate>
                    <asp:CheckBox   id="chkBox1" 
                                    runat="server" 
                                    AutoPostBack="true" 
                                    checked= '<%# Eval("IsPreBookVisibleBool") %>' 
                                    OnCheckedChanged="OnCheckedChanged_Event"
                                    ></asp:CheckBox>
                 </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
         protected void OnCheckedChanged_Event(object sender, System.EventArgs e)
            {
                CheckBox cb = sender as CheckBox;
                bool isChecked = cb.Checked; 
                DataGridItem dgi = cb.NamingContainer as DataGridItem;
                Label lbl = dgi.FindControl("IDLabel") as Label;
                string Id = lbl.Text as string; 
    }
