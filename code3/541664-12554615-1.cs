    DataRow row = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]); 
    string valToDelete = row[0].ToString();
    for (int i = 0; i < connexion.ds.Tables["Auteur"].Rows.Count; i++) 
        if (valToDelete == connexion.ds.Tables["Auteur"].Rows[i][0].ToString()) 
             connexion.ds.Tables["Auteur"].Rows[i].Delete(); 
    for (int i = 0; i < connexion.ds.Tables["AuteurGV"].Rows.Count; i++) 
        if (valToDelete == connexion.ds.Tables["AuteurGV"].Rows[i][0].ToString()) 
             connexion.ds.Tables["AuteurGV"].Rows[i].Delete(); 
    SqlCommandBuilder cmb = new SqlCommandBuilder(da); 
    da.Update(connexion.ds); 
    gridControl1.DataSource = connexion.ds.Tables["AuteurGV"]; 
