      public static DataTable SelectedColumns(DataTable RecordDT_, string col1, string col2)
        {
            DataTable TempTable = RecordDT_;
            System.Data.DataView view = new System.Data.DataView(TempTable);
            System.Data.DataTable selected = view.ToTable("Selected", false, col1, col2);
            return selected;
        }
