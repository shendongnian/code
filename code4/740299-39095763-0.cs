        void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        var grid = (DataGridView)sender;
        if (grid.Columns[e.ColumnIndex].Name == "IsActive")
        {
            e.Value = (bool)e.Value ? "True_Text_Replace" : "False_Text_Replace";
            e.FormattingApplied = true;
        }
    }
