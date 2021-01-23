            DataTable tbl2 = MainDataTable.Clone();
            tbl2.Merge(MainDataTable.Copy());
            tbl2.Merge(MainDataTable.Copy());
            tbl2.Merge(MainDataTable.Copy());
            tbl2.Columns.RemoveAt(0);
            tbl2.Columns.RemoveAt(1);
            tbl2.Columns[0].ColumnName = "SomeName";
            tbl2.Columns[1].ColumnName = "SomeName";
