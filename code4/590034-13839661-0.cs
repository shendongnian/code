                DataRow[] dr = dtable.Select("column1 ='" + valueToSearch +"'");
                DataRow newRow = dtable.NewRow();
                // We "clone" the row
                newRow.ItemArray = dr[0].ItemArray;
                // We remove the old and insert the new
                ds.Tables[0].Rows.Remove(dr[0]);
                ds.Tables[0].Rows.InsertAt(newRow, 0);
