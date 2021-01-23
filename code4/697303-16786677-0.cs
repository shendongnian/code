    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                AddRow(true);
            else
                AddRows();
        }
        protected void btn_AddNewItemField_Click(object sender, EventArgs e)
        {
            AddRow(true);
        }
        void AddRow(bool addCounter)
        {
            TableRow row = new TableRow();
    
            TableCell c1 = new TableCell();
            c1.Controls.Add(new TextBox());
    
            TableCell c2 = new TableCell();
            c2.Controls.Add(new DropDownList());
    
            row.Cells.Add(c1);
            row.Cells.Add(c2);
    
            this.tbl_Items.Rows.Add(row);
    
            if (addCounter)
            {
                if (ViewState["rowCount"] == null)
                    ViewState["rowCount"] = 1;
                else
                {
                    int count = ((int)ViewState["rowCount"]);
                    ViewState["rowCount"] = ++count;
                }
            }
        }
        void AddRows()
        {
            if (ViewState["rowCount"] == null)
                return;
            int count = ((int)ViewState["rowCount"]);
            for (int i = 1; i <= count; i++)
            {
                AddRow(false);
            }
        }
