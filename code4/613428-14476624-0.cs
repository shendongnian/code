    try
    {
    	var y = from ins in cstmrDC.customers_rd(Id) select ins;
    	var z = from ins in cstmrDC.customersCntcts_rd(Id) select ins;
    	DataTable dtCst;
    	DataTable dtDtls;
    	if (!ds1.Tables.Contains("dtCstmr"))
    	{
    		dtCst = new DataTable("dtCstmr");
    		dtCst.Columns.Add("cst_Id");
    		dtCst.Columns.Add("cst_Name");
    		dtCst.Columns.Add("cst_SName");
    		dtCst.Columns.Add("cst_AdLn1");
    		ds1.Tables.Add(dtCst);
    	}
    	else
    		dtCst = ds1.Tables["dtCstmr"];
    
    	if (!ds1.Tables.Contains("dtDtails"))
    	{
    		dtDtls = new DataTable("dtDtails");
    		dtDtls.Columns.Add("cst_SrlNo");
    		dtDtls.Columns.Add("cst_CntName");
    		dtDtls.Columns.Add("cst_cntDsgn");
    		ds1.Tables.Add(dtDtls);
    	}
    	else
    		dtDtls = ds1.Tables["dtDtails"];
    
    	foreach (var dtbl in y)
    	{
    		DataRow dr = dtCst.NewRow();
    		dr[0] = dtbl.cust_Id;
    		dr[1] = dtbl.cust_Name;
    		dr[2] = dtbl.cust_Sname;
    		dr[3] = dtbl.cust_Adrsln1;
    		dtCst.Rows.Add(dr);
    	}
    	
    	foreach (var dtbl in z)
    	{
    		DataRow drDtls = dtDtls.NewRow();
    		drDtls[0] = dtbl.cust_Slno;
    		drDtls[1] = dtbl.cust_Cntctnm;
    		drDtls[2] = dtbl.cust_Cntctdesig;
    		dtDtls.Rows.Add(drDtls);
    	}
    
    }
    catch (Exception ex)
    	{
    		MessageBox.Show(ex.Message);
    	}
