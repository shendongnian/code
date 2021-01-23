    protected void grid_OnRenderBrickEvent(object sender, ASPxGridViewExportRenderingEventArgs e)
    {
        if (e.RowType == GridViewRowType.Data && e.Column.FieldName == "yourcolumnfieldname")
        {
            string format = "0000000000.##";
            e.Text = ((decimal)e.Value).ToString(format);
            e.TextValue = ((decimal)e.Value).ToString(format);
    }
