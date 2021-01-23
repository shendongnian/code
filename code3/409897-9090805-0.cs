     public List<DataColumn> GetColumnInfoFromStoredProcResult(string schema, string storedProcName)
        {
            //build sql text
            var sb = new StringBuilder();
            sb.Append("SET FMTONLY OFF; SET FMTONLY ON; \n");//this is how EF4.1 did so I copied..not sure why the repeat
            sb.Append(String.Format("exec {0}.{1} ", schema, storedProcName));
            var prms = GetStoredProcedureParameters(schema: schema, sprocName: storedProcName);
            var count = 1;
            foreach (var param in prms)
            {
                sb.Append(String.Format("{0}=null", param.Name));
                if (count < prms.Count)
                {
                    sb.Append(", ");
                }
                count++;
            }
            sb.Append("\n SET FMTONLY OFF; SET FMTONLY OFF;");
            var ds = new DataSet();
            using (var sqlConnection = this.SqlConnection)
            {
                using (var sqlAdapter = new SqlDataAdapter(sb.ToString(), sqlConnection))
                {
                    if (sqlConnection.State != ConnectionState.Open) sqlConnection.Open();
                    sqlAdapter.SelectCommand.ExecuteReader(CommandBehavior.SchemaOnly);
                    sqlConnection.Close();
                    sqlAdapter.FillSchema(ds, SchemaType.Source, "MyTable");
                }
            }
            var list = ds.Tables[0].Columns.Cast<DataColumn>().ToList();
            return list;
        }
        public List<SqlParamInfo> GetStoredProcedureParameters(string schema, string sprocName)
        {
            var sqlText = String.Format(
                @"SELECT
	                [Name] = N'@RETURN_VALUE',
	                [ID] = 0,
	                [Direction] = 6,
	                [UserType] = NULL,
	                [SystemType] = N'int',
	                [Size] = 4,
	                [Precision] = 10,
	                [Scale] = 0
                WHERE
	                OBJECTPROPERTY(OBJECT_ID(N'{0}.{1}'), 'IsProcedure') = 1
                UNION
                SELECT
	                [Name] = CASE WHEN p.name <> '' THEN p.name ELSE '@RETURN_VALUE' END,
	                [ID] = p.parameter_id,
	                [Direction] = CASE WHEN p.is_output = 0 THEN 1 WHEN p.parameter_id > 0 AND p.is_output = 1 THEN 3 ELSE 6 END,
	                [UserType] = CASE WHEN ut.is_assembly_type = 1 THEN SCHEMA_NAME(ut.schema_id) + '.' + ut.name ELSE NULL END,
	                [SystemType] = CASE WHEN ut.is_assembly_type = 0 AND ut.user_type_id = ut.system_type_id THEN ut.name WHEN ut.is_user_defined = 1 OR ut.is_assembly_type = 0 THEN st.name WHEN ut.is_table_type =1 Then 'STRUCTURED' ELSE 'UDT' END,
	                [Size] = CONVERT(int, CASE WHEN st.name IN (N'text', N'ntext', N'image') AND p.max_length = 16 THEN -1 WHEN st.name IN (N'nchar', N'nvarchar', N'sysname') AND p.max_length >= 0 THEN p.max_length/2 ELSE p.max_length END),
	                [Precision] = p.precision,
	                [Scale] = p.scale
                FROM
	                sys.all_parameters p
	                INNER JOIN sys.types ut ON p.user_type_id = ut.user_type_id
	                LEFT OUTER JOIN sys.types st ON ut.system_type_id = st.user_type_id AND ut.system_type_id = st.system_type_id
                WHERE
	                object_id = OBJECT_ID(N'{0}.{1}') 
                ORDER BY 2", schema, sprocName);
            using (var sqlConnection = this.SqlConnection)
            {
                using (var sqlCommand = new SqlCommand())
                {
                    if (sqlConnection.State != ConnectionState.Open) sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = sqlText;
                    var dr = sqlCommand.ExecuteReader();
                    var result = new List<SqlParamInfo>();
                    while (dr.Read())
                    {
                        if (Convert.ToString(dr["Name"]) != "@RETURN_VALUE")
                        {
                            result.Add(new SqlParamInfo(dr));
                        }
                    }
                    return result;
                }
            }
        }
