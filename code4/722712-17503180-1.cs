    public dynamic m_DEMO_Return_var_method(string vpSchemaName, string vpTableName)
    {
        var var_List = new List<string>();
        var vColumnName = var_List.ToArray();
        try
        {
            DataTable iDataTable = new DataTable();
            var_List.Clear();
            foreach (DataRow iDataRow in iDataTable.Rows)
            {
                var_List.Add(iDataRow["COLUMN_NAME"].ToString());
            }
            vColumnName = var_List.ToArray();
            return vColumnName;
        }
        catch (Exception im_Exception)
        {
            return null;
        }
        finally
        {
        }
        return vColumnName;
    }
