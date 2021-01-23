            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Frequency");
            table.Columns.Add("Reports", typeof(List<string>));
            DataRow row1 = table.NewRow();
            row1["Name"] = "A";
            row1["Frequency"] = "Daily";
            List<string> report1 = new List<string>();
            report1.Add("XYZ");
            report1.Add("ABC");
            report1.Add("PQR");
            row1["Reports"] = report1;
            table.Rows.Add(row1);
            DataRow row2 = table.NewRow();
            row2["Name"] = "B";
            row2["Frequency"] = "Weekly";
            List<string> report2 = new List<string>();
            report2.Add("XYZ");
            row2["Reports"] = report2;
            table.Rows.Add(row2);
            reportScheduleDetailsGridView.DataSource = table;
            reportScheduleDetailsGridView.DataBind();
    <asp:GridView ID="reportScheduleDetailsGridView" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name"></asp:BoundField>
            <asp:BoundField DataField="Frequency" HeaderText="Frequency"></asp:BoundField>
            <asp:TemplateField HeaderText="Reports">
                <ItemTemplate>
                    <asp:Repeater ID="Repeater1" runat="server" DataSource='<%# Eval("Reports") %>'>
                        <ItemTemplate>
                            <%# (Container.ItemIndex+1)+"."+ Container.DataItem  %><br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
