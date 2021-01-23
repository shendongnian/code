    <asp:Table id="tbl_Items" runat="server"></asp:Table>
    <asp:Button ID="btn_AddNewItemField" runat="server" Text="Add New Item" />
        protected void Page_Load(object sender, EventArgs e)
        {
            TableRow row = new TableRow();
            
            TableCell c1 = new TableCell();
            c1.Controls.Add(new TextBox());
            TableCell c2 = new TableCell();
            c2.Controls.Add(new DropDownList());
            row.Cells.Add(c1);
            row.Cells.Add(c2);
            this.tbl_Items.Rows.Add(row);
            btn_AddNewItemField.Click += new EventHandler(btnAddNewItemFieldClick);
        }
        void btnAddNewItemFieldClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
