                    int[] selectedRows = gridViewDeduction.GetSelectedRows();
                    string type_id = gridViewDeduction.GetRowCellValue(selectedRows[0], gridViewDeduction.Columns["TypeId"]).ToString();
                    if (type_id != "")
                    {
                        string xsql = "DELETE FROM Pay_DeductionTypeMaster WHERE TypeId = " + type_id + " AND CompanyID = " + Global.CompanyID + "";
                        bool del = Database.ExecuteSQL(xsql);
                        if (!del)
                        {
                            XtraMessageBox.Show(Global.lk, "Unable to delete record.This deduction details is in use.", "Deduction Type");                          
                            return;
                        }
                        dt.Rows.RemoveAt(gridViewDeduction.FocusedRowHandle);
                    }
                    else
                        dt.Rows.RemoveAt(gridViewDeduction.FocusedRowHandle);
                    dt.AcceptChanges();
                    gridViewDeduction.RefreshData();
