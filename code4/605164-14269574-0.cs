    private void Form1_Load(object sender, EventArgs e)
    {
        // filling up example data
        var s = new List<InfoItem>();
        s.Add(new InfoItem() { PropertyA = "PA", PropertyB = 1, PropertyC = DateTime.Now, PropertyD = InfoItemType.Item_B });
        s.Add(new InfoItem() { PropertyA = "PB", PropertyB = 2, PropertyC = DateTime.Now, PropertyD = InfoItemType.Item_C });
        s.Add(new InfoItem() { PropertyA = "PC", PropertyB = 3, PropertyC = DateTime.Now, PropertyD = InfoItemType.Item_A });
        s.Add(new InfoItem() { PropertyA = "PD", PropertyB = 4, PropertyC = DateTime.Now, PropertyD = InfoItemType.Item_B });
        // assign my collection to the DataGrid
        dg.DataSource = s;
        // let's create one more column at the end
        var column = new DataGridViewColumn();
        column.CellTemplate = new DataGridViewTextBoxCell();
        column.HeaderText = "Custom Column";
        column.Name = "customColumn"; // important name to remember
        column.DataPropertyName = "PropertyD"; // the Enum Property
        dg.Columns.Add(column); // add the column
    }
    // let's make the use of the `CellFormatting` event
    private void dg_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // If the column is the "customColumn", check the value. 
        if (this.dg.Columns[e.ColumnIndex].Name == "customColumn")
        {
            if (e.Value != null)
            {
                // let's change to whatever we want...
                switch ((InfoItemType)e.Value)
                {
                    case InfoItemType.Item_A: e.Value = "I'm A"; break;
                    case InfoItemType.Item_B: e.Value = "I'm B"; break;
                    case InfoItemType.Item_C: e.Value = "I'm C"; break;
                    default: e.Value = "I'm not..."; break;
                }
            }
        }
    }
