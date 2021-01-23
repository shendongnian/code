    /// <summary>
        /// Combines the data of two data table into a single data table. The grouping of tables
        /// will be based on the primary key provided for both the tables.
        /// </summary>
        /// <param name="table1"></param>
        /// <param name="table2"></param>
        /// <param name="table1PrimaryKey"></param>
        /// <param name="table2PrimaryKey"></param>
        /// <returns></returns>
        private DataTable DataTablesOuterJoin(DataTable table1, DataTable table2, string table1PrimaryKey, string table2PrimaryKey)
        {
            DataTable flatDataTable = new DataTable();
            foreach (DataColumn column in table2.Columns)
            {
                flatDataTable.Columns.Add(new DataColumn(column.ToString()));
            }
            foreach (DataColumn column in table1.Columns)
            {
                flatDataTable.Columns.Add(new DataColumn(column.ToString()));
            }
            // Retrun empty table with required columns to generate empty extract
            if (table1.Rows.Count <= 0 && table2.Rows.Count <= 0)
            {
                flatDataTable.Columns.Remove(table2PrimaryKey);
                return flatDataTable;
            }
            var dataBaseTable2 = table2.AsEnumerable();
            var groupDataT2toT1 = dataBaseTable2.GroupJoin(table1.AsEnumerable(),
                                    br => new { id = br.Field<string>(table2PrimaryKey).Trim().ToLower() },
                                    jr => new { id = jr.Field<string>(table1PrimaryKey).Trim().ToLower() },
                                    (baseRow, joinRow) => joinRow.DefaultIfEmpty()
                                        .Select(row => new
                                        {
                                            flatRow = baseRow.ItemArray.Concat((row == null) ? new object[table1.Columns.Count] :
                                            row.ItemArray).ToArray()
                                        })).SelectMany(s => s);
            var dataBaseTable1 = table1.AsEnumerable();
            var groupDataT1toT2 = dataBaseTable1.GroupJoin(table2.Select(),
                                    br => new { id = br.Field<string>(table1PrimaryKey).Trim().ToLower() },
                                    jr => new { id = jr.Field<string>(table2PrimaryKey).Trim().ToLower() },
                                    (baseRow, joinRow) => joinRow.DefaultIfEmpty()
                                        .Select(row => new
                                        {
                                            flatRow = (row == null) ? new object[table2.Columns.Count].ToArray().Concat(baseRow.ItemArray).ToArray() :
                                            row.ItemArray.Concat(baseRow.ItemArray).ToArray()
                                        })).SelectMany(s => s);
            // Get the union of both group data to single set
            groupDataT2toT1 = groupDataT2toT1.Union(groupDataT1toT2);
            // Load the grouped data to newly created table 
            foreach (var result in groupDataT2toT1)
            {
                flatDataTable.LoadDataRow(result.flatRow, false);
            }
            // Get the distinct rows only
            IEnumerable rows = flatDataTable.Select().Distinct(DataRowComparer.Default);
            // Create a new distinct table with same structure as flatDataTable
            DataTable distinctFlatDataTable = flatDataTable.Clone();
            distinctFlatDataTable.Rows.Clear();
            // Push all the rows into distinct table.
            // Note: There will be two different columns for primary key1 and primary key2. In grouped rows,
            // primary key1 or primary key2 can have empty values. So copy all the primary key2 values to
            // primary key1 only if primary key1 value is empty and then delete the primary key2. So at last
            // we will get only one perimary key. Please make sure the non-deleted key must be present in 
            foreach (DataRow row in rows)
            {
                if (string.IsNullOrEmpty(row[table1PrimaryKey].ToString()))
                    row[table1PrimaryKey] = row[table2PrimaryKey];
                if (string.IsNullOrEmpty(row[CaptureBusDateColumn].ToString()))
                    row[CaptureBusDateColumn] = _businessDate;
                if (string.IsNullOrEmpty(row[CaptureUserIDColumn].ToString()))
                    row[CaptureUserIDColumn] = row[StatsUserIDColumn];
                distinctFlatDataTable.ImportRow(row);
            }
            // Sort the table based on primary key.
            DataTable sortedFinaltable = (from orderRow in distinctFlatDataTable.AsEnumerable()
                                          orderby orderRow.Field<string>(table1PrimaryKey)
                                          select orderRow).CopyToDataTable();
            // Remove primary key2 as we have already copied it to primary key1 
            sortedFinaltable.Columns.Remove(table2PrimaryKey);
            return ReplaceNulls(sortedFinaltable, "0");
        }
        /// <summary>
        /// Replace all the null values from data table with specified string 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="replaceStr"></param>
        /// <returns></returns>
        private DataTable ReplaceNulls(DataTable dt, string replaceStr)
        {
            for (int a = 0; a < dt.Rows.Count; a++)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Rows[a][i] == DBNull.Value)
                    {
                        dt.Rows[a][i] = replaceStr;
                    }
                }
            }
            return dt;
        }
