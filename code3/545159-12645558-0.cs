    foreach (DataRow row in dt.Rows)
                {
                if (row.RowState == DataRowState.Added)
                    {
                    row["CreatedOn"] = DateTime.Now;
                    row["CreatedBy"] = GlobalProp.UserName;
                    row["ModifiedOn"] = DateTime.Now;
                    row["ModifiedBy"] = GlobalProp.UserName;
                    }
                else if (row.RowState == DataRowState.Modified)
                    {
                    row["ModifiedOn"] = DateTime.Now;
                    row["ModifiedBy"] = GlobalProp.UserName;
                    }
                }
