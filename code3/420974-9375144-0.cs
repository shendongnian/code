    <asp:Panel Id="pnl" runat ="server">
        </asp:Panel>
    
    
    Label lblT = null;
                TextBox txt = null;
                Table tb = new Table();
                pnl.Controls.Add(tb);
                DataTable table = DT_GeneratedOp();
                foreach (DataColumn dr in table.Columns)
                {
                    TableRow tr = new TableRow();
                    TableCell tc = new TableCell();
                    TableCell tc2 = new TableCell();
                    lblT = new Label();
                    txt = new TextBox();
                    lblT.Text = dr.ColumnName + ":";
                    txt.Text = table.Rows[0][dr].ToString();
                    tc.Controls.Add(lblT);
                    tc2.Controls.Add(txt);
                    tr.Cells.Add(tc);
                    tr.Cells.Add(tc2);
                    tb.Rows.Add(tr);
                }
