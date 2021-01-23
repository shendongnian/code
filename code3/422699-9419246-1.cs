      public static bool GetNamesFromDatabase()
    {
        bool boolGetNameFromDatabase = false;
        {
            string strSql = string.Empty;
            string stkName_Key  = string.Empty;
            string stkName_Abrv = string.Empty;
            string stkName_Name = string.Empty;
            int intRecCount = 0;
            //int intCtr      = 0;
            OleDbConnection oleconnStkNames = null;
            OleDbDataReader oledrdrStkNames = null;
            try
            {
                oleconnStkNames = new OleDbConnection(strAccessConnectionString);
                oleconnStkNames.Open();
                using (OleDbCommand olecmdStkNames = new OleDbCommand(strSQLNames, oleconnStkNames))
                {
                    olecmdStkNames.CommandTimeout = 60;
                    olecmdStkNames.CommandType = System.Data.CommandType.Text;
                    oledrdrStkNames = olecmdStkNames.ExecuteReader();
                    while (oledrdrStkNames.Read())
                    {
                        List<string> lstDBFields = new List<string>();
                        //check if value = null
                        if (oledrdrStkNames["stkName_Key"].Equals(null))
                        {
                            stkName_Key = string.Empty;
                            lstDBFields.Add(stkName_Key);
                        }
                        else
                        {
                            lstDBFields.Add(oledrdrStkNames["stkName_Key"].ToString());
                        }
                        if (oledrdrStkNames["stkName_Abrv"].Equals(null))
                        {
                            stkName_Abrv = string.Empty;
                            lstDBFields.Add(stkName_Abrv);
                        }
                        else
                        {
                            lstDBFields.Add(oledrdrStkNames["stkName_Abrv"].ToString());
                        }
                        if (oledrdrStkNames["stkName_Name"].Equals(null))
                        {
                            stkName_Name = string.Empty;
                            lstDBFields.Add(stkName_Name);
                        }
                        else
                        {
                            lstDBFields.Add(oledrdrStkNames["stkName_Name"].ToString());
                        }
                         //this will old the NameFields.Count
                        lstDBFields.Add(0.ToString());
                        //dictionary to hold list of fields
                        //dictNames.Add(intRecCount, fields);
                        //HashTable to hold Key List<string>Value Pair
                        htblNames.Add(intRecCount, lstDBFields);
                        intRecCount++;
                    }
                    
                    if (intRecCount <= 0)
                    {
                        Console.WriteLine(strCriticalError);
                    }
                    else
                    {
                        boolGetNameFromDatabase = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (oledrdrStkNames != null)
                {
                    oledrdrStkNames.Close();
                    ((IDisposable)oleconnStkNames).Dispose();
                }
                if (oleconnStkNames != null)
                {
                    oleconnStkNames.Close();
                }
                
            }
        }
        return boolGetNameFromDatabase;
    }
