        public static string DataTableToJsonObj(DataTable dt)
        {
            DataSet ds = new DataSet();
            ds.Merge(dt);
            StringBuilder jsonString = new StringBuilder();
            if (ds.Tables[0].Rows.Count > 0)
            {
                jsonString.Append("[");
                for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                {
                    jsonString.Append("{");
                    for (int cols = 0; cols < ds.Tables[0].Columns.Count; cols++)
                    {
                        jsonString.Append(@"""" + ds.Tables[0].Columns[cols].ColumnName + @""":");
                        /* 
                        //IF NOT LAST PROPERTY
                        
                        if (cols < ds.Tables[0].Columns.Count - 1)
                        {
                            GenerateJsonProperty(ds, rows, cols, jsonString);
                        }
                        
                        //IF LAST PROPERTY
                        
                        else if (cols == ds.Tables[0].Columns.Count - 1)
                        {
                            GenerateJsonProperty(ds, rows, cols, jsonString, true);
                        }
                        */
                        var b = (cols < ds.Tables[0].Columns.Count - 1)
                            ? GenerateJsonProperty(ds, rows, cols, jsonString)
                            : (cols != ds.Tables[0].Columns.Count - 1)
                              || GenerateJsonProperty(ds, rows, cols, jsonString, true);
                    }
                    jsonString.Append(rows == ds.Tables[0].Rows.Count - 1 ? "}" : "},");
                }
                jsonString.Append("]");
                return jsonString.ToString();
            }
            return null;
        }
        private static bool GenerateJsonProperty(DataSet ds, int rows, int cols, StringBuilder jsonString, bool isLast = false)
        {
            // IF LAST PROPERTY THEN REMOVE 'COMMA'  IF NOT LAST PROPERTY THEN ADD 'COMMA'
            string addComma = isLast ? "" : ",";
            if (ds.Tables[0].Rows[rows][cols] == DBNull.Value)
            {
                jsonString.Append(" null " + addComma);
            }
            else if (ds.Tables[0].Columns[cols].DataType == typeof(DateTime))
            {
                jsonString.Append(@"""" + (((DateTime)ds.Tables[0].Rows[rows][cols]).ToString("yyyy-MM-dd HH':'mm':'ss")) + @"""" + addComma);
            }
            else if (ds.Tables[0].Columns[cols].DataType == typeof(string))
            {
                jsonString.Append(@"""" + (ds.Tables[0].Rows[rows][cols]) + @"""" + addComma);
            }
            else if (ds.Tables[0].Columns[cols].DataType == typeof(bool))
            {
                jsonString.Append(Convert.ToBoolean(ds.Tables[0].Rows[rows][cols]) ? "true" : "fasle");
            }
            else
            {
                jsonString.Append(ds.Tables[0].Rows[rows][cols] + addComma);
            }
            return true;
        }
