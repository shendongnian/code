     public override void DataBind()
            {
                ...
                GridViewDataTextColumn myCol = new GridViewDataTextColumn();
                myCol.Caption = "col1";
                myCol.FieldName = "dataTableField1";
                theGridView.Columns.Clear();
                theGridView.Columns.Add(myCol);
                theGridView.DataSource = AdjustDataSource();
                theGridView.DataBind();
                myCol.DataItemTemplate = new ColumnDataItemTemplate();
                ...
            }
