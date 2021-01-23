    public void AddColumnToDic(object value, string columnName) 
        bool skipNullValues = false; // todo: read from configuration
        if ((value != DBNull.Value) || (value == DBNull.Value && !skipNullValues))
        {
            dic.Add(columnName);
        }
    }
