    void InitGrid() {
        gridControl1.DataSource = new List<Person> { 
            new Person(){ ID = 0 }, 
            new Person(){ ID = 1 }, 
            new Person(){ ID = 2 }
        };
        gridView.Columns["ID"].Visible = false;
        gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
        {
            UnboundType = DevExpress.Data.UnboundColumnType.Boolean,
            Caption = "Mark as Deleted",
            FieldName = "IsDeleted",
            Visible = true,
        });
    }
    IDictionary<int, object> selectedRows = new Dictionary<int, object>();
    void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
        int id = (int)gridView.GetListSourceRowCellValue(e.ListSourceRowIndex, gridView.Columns["ID"]);
        if(e.IsGetData) 
            e.Value = selectedRows.ContainsKey(id);
        else {
            if(!(bool)e.Value)
                selectedRows.Remove(id);
            else selectedRows.Add(id, e.Row);
        }
    }
    void OnDelete(object sender, System.EventArgs e) {
        //... Here you can iterate thought selectedRows dictionary
    }
    //
    class Person {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
    }
 
