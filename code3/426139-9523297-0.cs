            DataTable dt = new DataTable();
            dt.Columns.Add("FirstName");
            dt.Columns.Add("Age");
            dt.Rows.Add("rambo", 60);
            dt.Rows.Add("Arnie", 35);
            bindingSource1.DataSource = dt;
            gridControl1.DataSource = bindingSource1;
            gridView1.RefreshData();
            gridView1.Columns.Add(
                new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    Caption = "Selected",
                    ColumnEdit = new RepositoryItemCheckEdit() { },
                    VisibleIndex = 0,
                    UnboundType = DevExpress.Data.UnboundColumnType.Boolean
                }
                );
