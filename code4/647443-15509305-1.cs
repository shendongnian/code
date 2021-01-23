    protected void Page_Load(object sender, EventArgs e)
    {
        Title = table.DisplayName;
        // Disable various options if the table is readonly
        if (table.IsReadOnly)
        {
            GridView1.Columns[0].Visible = false;
            InsertHyperLink.Visible = false;
            GridView1.EnablePersistedSelection = false;
        }
        // Add our sort to the first data column.
        if (!Page.IsPostBack)
        {
            GridView1.Sort(table.Columns[0].Name, SortDirection.Ascending);
        }
    }
