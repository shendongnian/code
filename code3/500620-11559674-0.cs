        private void CreateUpdate()
        {
            //UPDATE "TABLE" SET "AD_USERID" = :AD_USERID,  WHERE (("AD_USERID" = :Original_AD_USERID) AND ("MODULE" = :Original_MODULE)) AND ((:IsNull_MODIFIED_BY = 1 AND ""MODIFIED_BY"" IS NULL) OR (""MODIFIED_BY"" = :Original_MODIFIED_BY))
            DataTable tbl = _DsViews.Tables[_DbName];
            string value = string.Empty;
            string where = string.Empty;
            foreach (DataColumn col in tbl.Columns)
            {
                value += string.Format("\"{0}\" = :{0},", col.ColumnName.ToUpper());
                if (GetOraType(col.DataType) == OracleType.Blob)
                    continue;
                if (col.AllowDBNull || col.DataType == typeof(DateTime))
                    where += string.Format("((:IsNull_{0} = 1 AND \"{0}\" IS NULL) OR (\"{0}\" = :Original_{0})) AND ", col.ColumnName.ToUpper());
                else 
                    where += string.Format("(\"{0}\" = :Original_{0}) AND ", col.ColumnName.ToUpper());
            }
            value = value.Substring(0, value.Length - 1);
            where = where.Substring(0, where.Length - 5);
            string sql = string.Format("UPDATE \"{0}\"  SET {1} WHERE ({2})", _DbName, value, where);
            ta.UpdateCommand = new OracleCommand(sql, MyDBConnection);
            foreach (DataColumn col in tbl.Columns)
            {
                ta.UpdateCommand.Parameters.Add(new OracleParameter(col.ColumnName.ToUpper(), GetOraType(col.DataType), 0, ParameterDirection.Input, col.ColumnName.ToUpper(), DataRowVersion.Current, false, null));
                if (GetOraType(col.DataType) == OracleType.Blob)
                    continue;
                if (col.AllowDBNull || col.DataType == typeof(DateTime))
                    ta.UpdateCommand.Parameters.Add(new OracleParameter("IsNull_" + col.ColumnName.ToUpper(), OracleType.Int32, 0, ParameterDirection.Input, col.ColumnName.ToUpper(), DataRowVersion.Original, true, null));
                ta.UpdateCommand.Parameters.Add(new OracleParameter("Original_" + col.ColumnName.ToUpper(), GetOraType(col.DataType), 0, ParameterDirection.Input, col.ColumnName.ToUpper(), DataRowVersion.Original, false, null));
            }
        }
