     object IDataRecord.GetValue(int i)
        {
            object columnValue = reader.GetValue(i);
            if (i > -1 && i < lookup.Length)
            {
                DataRow columnDef = lookup[i];
                if
                (
                    (
                        (string)columnDef["DataTypeName"] == "varchar" ||
                        (string)columnDef["DataTypeName"] == "nvarchar" ||
                        (string)columnDef["DataTypeName"] == "char" ||
                        (string)columnDef["DataTypeName"] == "nchar"
                    ) &&
                    (
                        columnValue != null &&
                        columnValue != DBNull.Value
                    )
                )
                {
                    string stringValue = columnValue.ToString().Trim();
                    columnValue = stringValue;
                    
                    if (stringValue.Length > (int)columnDef["ColumnSize"])
                    {
                        string message =
                            "Column value \"" + stringValue.Replace("\"", "\\\"") + "\"" +
                            " with length " + stringValue.Length.ToString("###,##0") +
                            " from source column " + (this as IDataRecord).GetName(i) +
                            " in record " + currentRecord.ToString("###,##0") +
                            " does not fit in destination column " + columnDef["ColumnName"] +
                            " with length " + ((int)columnDef["ColumnSize"]).ToString("###,##0") +
                            " in table " + tableName +
                            " in database " + databaseName +
                            " on server " + serverName + ".";
                        if (ColumnException == null)
                        {
                            throw new Exception(message);
                        }
                        else
                        {
                            ColumnExceptionEventArgs args = new ColumnExceptionEventArgs();
                            args.DataTypeName = (string)columnDef["DataTypeName"];
                            args.DataType = Type.GetType((string)columnDef["DataType"]);
                            args.Value = columnValue;
                            args.SourceIndex = i;
                            args.SourceColumn = reader.GetName(i);
                            args.DestIndex = (int)columnDef["ColumnOrdinal"];
                            args.DestColumn = (string)columnDef["ColumnName"];
                            args.ColumnSize = (int)columnDef["ColumnSize"];
                            args.RecordIndex = currentRecord;
                            args.TableName = tableName;
                            args.DatabaseName = databaseName;
                            args.ServerName = serverName;
                            args.Message = message;
                            ColumnException(args);
                            columnValue = args.Value;
                        }
                    }
                    
                }
            }
            return columnValue;
        }
