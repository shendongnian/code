            foreach (DataRow dr in dt.Rows)
            {
                if (dr.RowState == DataRowState.Modified)
                {
                    var changedCols = new List<DataColumn>();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        if (!dr[dc, DataRowVersion.Original].Equals(
                             dr[dc, DataRowVersion.Current])) /* skipped Proposed as indicated by a commenter */
                        {
                            changedCols.Add(dc);
                        }
                    }
                    // now handle the changedCols list
                }
            }
