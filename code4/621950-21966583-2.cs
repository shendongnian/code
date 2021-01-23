        private void GenerateTable()
        {
        ...
         var label = new Label { Text = "bla bla", Width = 150 };
         tableRow.Cells.Add(label );
         Table1.Rows.Add(tableRow);
         Session.Add("Table1", Table1);
        ...
        }
    
         protected void Page_Load(object sender, EventArgs e)
            {
                var myDynamicTable = Session["Table1"] as Table;
    
                if ( myDynamicTable != null)
                {
                    foreach(var row in myDynamicTable.Rows)
                    {
                        this.Table1.Rows.Add(row as TableRow);
                    }
    
                    Session.Add("Table1", Table1);
                }
    
                if (!IsPostBack)
                {
    
                }
    
            }
