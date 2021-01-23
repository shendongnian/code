        SqlDataAdapter da = new SqlDataAdapter("select Id, Material from Master.Materialname", objConn1); 
        DataTable dt = new DataTable(); 
        da.Fill(dt); 
        DataRow dr; 
        dr = dt.NewRow(); 
        comboBox3.DisplayMember = "Material"; 
        comboBox3.ValueMember = "Id"; 
        comboBox3.DataSource = dt; 
    
    write below code on combobox3 changed event
    
        int newid = comboBox3.selectedvalue;
    
        //Loading comboBox4
        SqlDataAdapter da1 = new SqlDataAdapter("select Id, Process from Master.ProductionProcess and Id = " + newid , objConn1); 
        DataTable dt1 = new DataTable(); 
        da1.Fill(dt1); `enter code here`
        DataRow dr1; 
        dr1 = dt1.NewRow(); 
        comboBox4.DisplayMember = "Process"; 
        comboBox4.ValueMember = "Id"; 
        comboBox4.DataSource = dt1; 
        objConn1.Close(); 
