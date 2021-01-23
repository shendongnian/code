    protected void Page_Load(object sender, EventArgs e)
    {
        //Generate the Rows on Initial Load
        if (!Page.IsPostBack)
        {
            GenerateTable(numOfRows);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ViewState["RowsCount"] != null)
        {
            numOfRows = Convert.ToInt32(ViewState["RowsCount"].ToString());
            GenerateTable(numOfRows);
        }
    }
    protected void SaveTextBoxValues_Click(object sender, EventArgs e)
    {
        string AllTextBoxValues = hfTextValues.Value;
        string[] EachTextBoxValue = AllTextBoxValues.Split('~');
        //here you would get all values, EachTextBoxValue[0] gives value of first textbox and so on.
    }
    private void GenerateTable(int rowsCount)
    {
        //Creat the Table and Add it to the Page
        Table table = new Table();
        table.ID = "Table1";
        Page.Form.Controls.Add(table);
        //The number of Columns to be generated
        const int colsCount = 3;//You can changed the value of 3 based on you requirements
        // Now iterate through the table and add your controls
        for (int i = 0; i < rowsCount; i++)
        {
            TableRow row = new TableRow();
            for (int j = 0; j < colsCount; j++)
            {
                TableCell cell = new TableCell();
                TextBox tb = new TextBox();
                HiddenField hf = new HiddenField();
                // Set a unique ID for each TextBox added
                tb.ID = "tb" + i + j;
                hf.ID = "hf" + i + j;
                tb.Attributes.Add("onblur", "fncTextChanged(this.value);");
                // Add the control to the TableCell
                cell.Controls.Add(tb);
                // Add the TableCell to the TableRow
                row.Cells.Add(cell);
            }
            // And finally, add the TableRow to the Table
            table.Rows.Add(row);
        }
    }
