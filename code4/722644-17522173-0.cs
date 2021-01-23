            SPGridView _gridview = new SPGridView();
            DataTable table = /*some data*/;
            _gridview.Enabled = true;
            _gridview.AutoGenerateColumns = false;
            _gridview.Visible = true;
            foreach(DataColumn col in table.Columns)
            {
                SPBoundField field = new SPBoundField();
                field.DataField = col.ColumnName;
                _gridview.Columns.Add(field);
            }
            _gridview.DataSource = table;
            _gridview.DataBind();
            this.Controls.Add(_gridview);
