    public string Heading1 { get; set; }
    public string Heading2 { get; set; }
    public string Heading3 { get; set; }
    public string Heading4 { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Heading1 = "Heading 1";
        Heading2 = "Heading 2";
        Heading3 = "Heading 3";
        Heading4 = "Heading 4";
        
        var list = new List<string> { "Column1", "Column2", "Column3" };
        var table = new DataTable();
        table.Columns.Add(new DataColumn("Rego No", typeof(string)));
        foreach (var item in list)
            table.Columns.Add(item, typeof(string));
        //Now add some rows(which will be repeated in the ItemTemplate)
        table.Rows.Add("0", "Row 0", "Row 0", "Row 0");
        table.Rows.Add("1", "Row 1", "Row 1", "Row 1");
        table.Rows.Add("2", "Row 2", "Row 2", "Row 2");
        dlcalender.DataSource = table;
        dlcalender.DataBind();
    }
