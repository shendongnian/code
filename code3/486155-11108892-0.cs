    protected void Button_addMedicacao0_Click(object sender, EventArgs e){
    String strConnection1 = "conectionstring1";
    String strConnection2 = "conectionstring2";
    try
    {
        OleDbConnection dbConn = null;
        OleDbCommand dbCmd = null;
        OleDbDataReader dr = null;
        String strSQL = null;
        dbConn = new OleDbConnection(strConnection1);
        dbConn.Open();
        strSQL = "select * from TABLE1";
        dbCmd = new OleDbCommand(strSQL, dbConn);
        dr = dbCmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                try
                {
                    OleDbConnection dbConn2 = null;
                    OleDbCommand dbCmd2 = null;
                    String strSQL2 = null;
                    dbConn2 = new OleDbConnection(strConnection2);
                    dbConn2.Open();
                    strSQL = "INSERT INTO TABLE2 (Field1, Field2) VALUES (?, ?)";
                    dbCmd2 = new OleDbCommand(strSQL2, dbConn2);
                    // dr[0] = id_table1
                    dbCmd2.Parameters.Add(new OleDbParameter("Field1", dr[1].ToString()));
                    dbCmd2.Parameters.Add(new OleDbParameter("Field2", dr[2].ToString()));                       
                    dbCmd2.ExecuteNonQuery();
                    dbConn2.Close();
                }
                catch (Exception err)
                { 
                }
            }
        }
        dbConn.Close();
    }
    catch (Exception err)
    {  
    }
    }
