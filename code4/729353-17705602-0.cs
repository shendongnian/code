        /// <summary>
        /// Joins the passed in DataTables on the colToJoinOn.
        /// <para>Returns an appropriate DataTable with zero rows if the colToJoinOn does not exist in both tables.</para>
        /// </summary>
        /// <param name="dtblWithUniqueValuesInColumn"></param>
        /// <param name="dtblWithExtraData"></param>
        /// <param name="colToJoinOn"></param>
        /// <returns></returns>
        /// <remarks>http://stackoverflow.com/questions/2379747/create-combined-datatable-from-two-datatables-joined-with-linq-c-sharp?rq=1</remarks>
        public static DataTable LeftOuterJoinTwoDataTablesOnOneColumn(DataTable dtblWithUniqueValuesInColumn, DataTable dtblWithExtraData, string colToJoinOn)
        {
            //Get columns from dtblA
            DataTable dtblResult = dtblWithUniqueValuesInColumn.Clone();
            //Get columns from dtblB
            var dt2Columns = dtblWithExtraData.Columns.OfType<DataColumn>().Select(dc => new DataColumn(dc.ColumnName, dc.DataType, dc.Expression, dc.ColumnMapping));
            //Get columns from dtblB that are not in dtblA
            var dt2FinalColumns = from dc in dt2Columns.AsEnumerable()
                                  where !dtblResult.Columns.Contains(dc.ColumnName)
                                  select dc;
            //Add missing columns to dtblResult
            dtblResult.Columns.AddRange(dt2FinalColumns.ToArray());
            //No reason to continue if the colToJoinOn does not exist in both DataTables.
            if (!dtblWithUniqueValuesInColumn.Columns.Contains(colToJoinOn) || !dtblWithExtraData.Columns.Contains(colToJoinOn))
            {
                dtblResult.Columns.Add(colToJoinOn);
                return dtblResult;
            }
            //Create row data by concatenating data from matching rows
            var rowData = from row1 in dtblWithUniqueValuesInColumn.AsEnumerable()
                          join row2 in dtblWithExtraData.AsEnumerable()
                          on row1[colToJoinOn] equals row2[colToJoinOn]
                          select row1.ItemArray.Concat(row2.ItemArray.Where(r2 => !row1.ItemArray.Contains(r2))).ToArray();
            //Add row data to dtblResult
            foreach (object[] values in rowData)
                dtblResult.Rows.Add(values);
            return dtblResult;
        }
