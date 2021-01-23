    private void setLabelText( IDataRecord dr, string columnName, Label label )
    {
        label.Text = string.Empty
        if (dr[columnName] != DBNull.Value)
        {
            label.Text = dr[columnName].ToString();
        }
    }
