    using (var cmd = new OleDbCommand("Update TableName Set StringTypeColmName = ?, NumberTypeColmName = ?", connection))
    {
        cmd.Parameters.AddWithValue("string", "StringValue");
        cmd.Parameters.AddWithValue("num", !string.IsNullOrEmpty(cmbCity.Text) ? cmbCity.SelectedValue : DBNull.Value);
    
        cmd.ExecuteNonQuery();
    }
