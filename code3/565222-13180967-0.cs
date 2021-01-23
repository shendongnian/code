    static void SaveToMDB(DataSet ds, string strMDBFile)
    {
        OleDbConnection cAccess = new OleDbConnection(
            "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + strMDBFile);
        cAccess.Open();
    
        foreach (DataTable oTable in ds.Tables)
        {
            OleDbCommand oCommand = new OleDbCommand(
                "DROP TABLE [" + oTable.TableName + "]", cAccess);
            try
            {
                oCommand.ExecuteNonQuery();
            }
            catch (Exception) { }
    
            string strCreateColumns = "";
            string strColumnList = "";
            string strQuestionList = "";
            foreach (DataColumn oColumn in oTable.Columns)
            {
                strCreateColumns += "[" + oColumn.ColumnName + "] VarChar(255), ";
                strColumnList += "[" + oColumn.ColumnName + "],";
                strQuestionList += "?,";
            }
            strCreateColumns = strCreateColumns.Remove(strCreateColumns.Length - 2);
            strColumnList = strColumnList.Remove(strColumnList.Length - 1);
            strQuestionList = strQuestionList.Remove(strQuestionList.Length - 1);
    
            oCommand = new OleDbCommand("CREATE TABLE [" + oTable.TableName
                + "] (" + strCreateColumns + ")", cAccess);
            oCommand.ExecuteNonQuery();
    
            OleDbDataAdapter da = new OleDbDataAdapter(
                "SELECT * FROM [" + oTable.TableName + "]", cAccess);
            da.MissingSchemaAction = MissingSchemaAction.Add;
            da.FillLoadOption = LoadOption.OverwriteChanges;
    
            da.InsertCommand = new OleDbCommand(
                "INSERT INTO [" + oTable.TableName + "] (" + strColumnList
                + ") VALUES (" + strQuestionList + ")", cAccess);
            foreach (DataColumn oColumn in oTable.Columns)
            {
                da.InsertCommand.Parameters.Add(
                    oColumn.ColumnName,
                    OleDbType.VarChar,
                    255,
                    oColumn.ColumnName
                    );
            }
    
            foreach (DataRow oRow in oTable.Rows)
                oRow.SetAdded();
            da.Update(oTable);
        }
    }
