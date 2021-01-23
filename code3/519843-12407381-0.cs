    public static DataTable AddNewAllocations(string pCaseNo, DataTable pTable)
        {
            try
            {
                DataTable newTable = NewAllocationTable(); 
                string sqlText = "SELECT UserID FROM tblUsers;";
                aSqlQuery aQ = new aSqlQuery(sqlText, "table");
                DataTable userTable = aQ.TableResult;
                foreach (DataRow userRow in userTable.Rows)
                {
                    int allocAlready = 0;
                    foreach (DataRow allocRow in pTable.Rows)
                    {
                        if (allocRow["FeeEarner"].ToString() == userRow["UserID"].ToString())
                        {
                            allocAlready = 1;                            
                        }
                    }
                    
                    if (allocAlready == 0)
                    {
                        string strUser = userRow["UserID"].ToString();          
                        decimal fees = cTimesheet.UserFees(strUser, pCaseNo);
                        int intCaseNo = Int32.Parse(pCaseNo);
                        if (fees > 0)
                        {
                            Object[] array = new object[8];
                            array[0] = 0;
                            array[1] = intCaseNo;
                            array[2] = DateTime.Today;
                            array[3] = strUser;
                            array[4] = fees;
                            array[5] = 0;
                            array[6] = fees;
                            array[7] = true;
                            newTable.Rows.Add(array);
                        }
                    }
                }
                foreach (DataRow row in pTable.Rows)
                {
                    newTable.ImportRow(row);
                }
                newTable.DefaultView.Sort = "AllocID";
                return newTable;
            }
            catch (Exception eX)
            {
                throw new Exception("cAllocation: Error in NewAllocations()" + Environment.NewLine + eX.Message);
            }
        }
