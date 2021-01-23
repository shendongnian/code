    public void CreateTables(DataSet ds1) {
      var dtCst = new DataTable("dtCstmr");
      dtCst.Columns.Add("cst_Id");
      dtCst.Columns.Add("cst_Name");
      dtCst.Columns.Add("cst_SName");
      dtCst.Columns.Add("cst_AdLn1");
    
      var dtDtls = new DataTable("dtDtails");
      dtDtls.Columns.Add("cst_SrlNo");
      dtDtls.Columns.Add("cst_CntName");
      dtDtls.Columns.Add("cst_cntDsgn");
      
      ds1.Tables.Add(dtCst);
      ds1.Tables.Add(dtDtls);
    }
    
    public void FillDataSet(DataSet ds1,int Id)
       {
           try
           {
               var y = from ins in cstmrDC.customers_rd(Id) select ins;
               var z = from ins in cstmrDC.customersCntcts_rd(Id) select ins;
    
               var dtCst = ds1.Tables["dtCstmr"];
               var dtDtls = ds1.Tables["dtDtails"];
               dtCst.Clear();
               dtDtls.Clear();
    
    
               foreach (var dtbl in y)
               {
                   DataRow dr;
                   dr = dtCst.NewRow();
                   dr[0] = dtbl.cust_Id;
                   dr[1] = dtbl.cust_Name;
                   dr[2] = dtbl.cust_Sname;
                   dr[3] = dtbl.cust_Adrsln1;
                   dtCst.Rows.Add(dr);
    
               }
               foreach (var dtbl in z)
               {
                   DataRow drDtls;
                   drDtls = dtDtls.NewRow();
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
       }
    
   
