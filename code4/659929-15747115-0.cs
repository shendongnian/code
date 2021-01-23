    private void button1_Click(object sender, EventArgs e) // wczytanie excela 
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
    
        var dialogResult = openFileDialog1.ShowDialog();
        string sWybranyPlik;
        
        if (dialogResult  == DialogResult.OK)
        {
          sWybranyPlik = openFileDialog1.FileName;
    
          try
          {
             using(OleDbConnection ExcelConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + sWybranyPlik + "';Extended Properties=Excel 8.0;"))
             {
    		 OleDbDataAdapter OleDBAdapter = new OleDbDataAdapter("select * from [Tabelle1$]", ExcelConnection);
    
    		 OleDBAdapter.Fill(DtSet.Tables[0]);
    		 dataGridView1.DataSource = DtSet.Tables[0];
    
                 -- recommendation: always explicitly *specify* the columns of the table
                 -- that you're inserting into
    		 string strQuery = @"INSERT INTO TabelaProdukty(col1, col2, col3,....., colN)
    				     VALUES (@VD, @ItemCode, @Item, @Qty, @Ppcur, @StandardPrice, @CeMarked, @Description, @Description2, @Edma)";
    
                     using(sqlconnection = new SqlCeConnection("Data Source = C:\\Users\\user\\Documents\\Visual Studio 2010\\Projects\\BMGRP\\Oferty BMGRP\\Oferty BMGRP\\bin\\Debug\\BazaDanych.sdf"))
      		 using(SqlCeCommand comm = new SqlCeCommand(strQuery, sqlconnection))
    		 {
    		     comm.Parameters.AddWithValue("@VD", dataGridView1.Rows[i].Cells["VD"].Value);
    		     comm.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
    		     comm.Parameters.AddWithValue("@Item", dataGridView1.Rows[i].Cells["ITEM"].Value);
    		     comm.Parameters.AddWithValue("@Qty", dataGridView1.Rows[i].Cells["QUANTITY"].Value);
    		     comm.Parameters.AddWithValue("@Ppcur", dataGridView1.Rows[i].Cells["PPCUR"].Value);
    		     comm.Parameters.AddWithValue("@StandardPrice", dataGridView1.Rows[i].Cells["STANDARD_SELL_PRICE"].Value);
    		     comm.Parameters.AddWithValue("@CeMarked", dataGridView1.Rows[i].Cells["CE-MARKED"].Value);
    		     comm.Parameters.AddWithValue("@Description", dataGridView1.Rows[i].Cells["ITEM_DESCRIPTION"].Value);
    		     comm.Parameters.AddWithValue("@Description2", dataGridView1.Rows[i].Cells["ITEM_DESCRIPTION2"].Value);
    		     comm.Parameters.AddWithValue("@Edma", dataGridView1.Rows[i].Cells["EDMA"].Value);
    
    		     sqlconnection.Open();
    		     comm.ExecuteNonQuery();
    		     sqlconnection.Close();
    		 }
    
    		 ExcelConnection.Close();
              }		 
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.ToString());
          }
        }
