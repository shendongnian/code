    DataSet dsEmployeeOrg = eCorporateStaffMgr.GetEmployeeAccessLevel(oEmp);
    DataTable dt = dsEmployeeOrg[0];
    string sManagerID = "";
    string sSupervisorID = "";
    string sEmployeeID = "";
    
    for (int i = 0; i < dsEmployeeOrg.Tables[0].Rows.Count; i++)
    {
       sManagerID = dt.Rows[i].ItemArray[3].ToString().Trim();
       sSupervisorID = dt.Rows[i].ItemArray[4].ToString().Trim();
       sEmployeeID = dt.Rows[i].ItemArray[5].ToString().Trim();
    
       if ((sManagerID.ToString().Trim() != sSupervisorID.ToString().Trim()) && (sManagerID.ToString().Trim() != sEmployeeID.ToString().Trim()))
       {
           if (sSupervisorID.ToString().Trim() == sEmployeeID.ToString().Trim())
           {
              // This is a Supervisor record
              dt.Rows[i][2] = "1111";
           }
           else if (sSupervisorID.ToString().Trim() != sEmployeeID.ToString().Trim())
           {
              //This is a Employee record
              dt.Rows[i][2] = "0000";
           }
       }
    }
