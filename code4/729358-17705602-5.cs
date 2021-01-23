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
            //Change column name to a temp name so the LINQ for getting row data will work properly.
            string strTempColName = colToJoinOn + "_2";
            if (dtblWithExtraData.Columns.Contains(colToJoinOn))
                dtblWithExtraData.Columns[colToJoinOn].ColumnName = strTempColName;
            //Get columns from dtblWithUniqueValuesInColumn
            DataTable dtblResult = dtblWithUniqueValuesInColumn.Clone();
            //Get columns from dtblWithExtraData
            var dt2Columns = dtblWithExtraData.Columns.OfType<DataColumn>().Select(dc => new DataColumn(dc.ColumnName, dc.DataType, dc.Expression, dc.ColumnMapping));
            //Get columns from dtblWithExtraData that are not in dtblWithUniqueValuesInColumn
            var dt2FinalColumns = from dc in dt2Columns.AsEnumerable()
                                  where !dtblResult.Columns.Contains(dc.ColumnName)
                                  select dc;
            //Add the rest of the columns to dtblResult
            dtblResult.Columns.AddRange(dt2FinalColumns.ToArray());
            //No reason to continue if the colToJoinOn does not exist in both DataTables.
            if (!dtblWithUniqueValuesInColumn.Columns.Contains(colToJoinOn) || (!dtblWithExtraData.Columns.Contains(colToJoinOn) && !dtblWithExtraData.Columns.Contains(strTempColName)))
            {
                if (!dtblResult.Columns.Contains(colToJoinOn))
                    dtblResult.Columns.Add(colToJoinOn);
                return dtblResult;
            }
            //get row data
            var rowData = from row1 in dtblWithUniqueValuesInColumn.AsEnumerable()
                          join row2 in dtblWithExtraData.AsEnumerable()
                          on row1[colToJoinOn] equals row2[strTempColName]
                          select row1.ItemArray.Concat(row2.ItemArray).ToArray();
            //Add row data to dtblResult
            foreach (object[] values in rowData)
                dtblResult.Rows.Add(values);
            //Change column name back to original
            dtblWithExtraData.Columns[strTempColName].ColumnName = colToJoinOn;
            //Remove extra column from result
            dtblResult.Columns.Remove(strTempColName);
            return dtblResult;
        }
