    public bool isValidField(string tableName, string columnName)
    {
        bool retVal;
        string tblQuery = "SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @tableName AND COLUMN_NAME = @columnName";
        checkConnection();
        try
        {
            SqlCeCommand cmd = objCon.CreateCommand();
            cmd.CommandText = tblQuery;
            SqlCeParameter tblNameParam = new SqlCeParameter("@tableName", SqlDbType.NVarChar, 128);
            tblNameParam.Value = tableName;
            cmd.Parameters.Add(tblNameParam);
            SqlCeParameter colNameParam = new SqlCeParameter("@columnName", SqlDbType.NVarChar, 128);
            colNameParam.Value = tableName;
            cmd.Parameters.Add(colNameParam);
            object objvalid = cmd.ExecuteScalar();
            retVal = !Convert.IsDBNull(objvalid);
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
            retVal = false; // <-- wrong answer
        }
        return retVal;
    }
