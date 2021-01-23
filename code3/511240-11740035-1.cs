    DataTable dt1 = new DataTable();  // for temporary storage
    DataSet1TableAdapters.sp_Units_GetUnitState  objAda = new DataSet1TableAdapters.sp_Units_GetUnitState();
    dt1 = objAda.GetData(txtPadidehOrAtkinsCode.Text);
    // Now get the state from the datatable
    string state = dt1.Rows[0][0].ToString();
    
