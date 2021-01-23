    try
    {
       cn = db.createConnection();
       if (cn.State == System.Data.ConnectionState.Open)
       {
           cn.Close();
       }
       cn.Open();
       cmd = new OleDbCommand("Select BillNo,PartyName,City,State,FORMAT(BillDt,'dd-mm-yyyy') as BillDt from BillMaster", cn);
       da = new OleDbDataAdapter(cmd);
       ds = new DataSet();
       da.Fill(ds);
       cn.Close();
       dataGridView1.AutoGenerateColumns = true;
       dataGridView1.DataSource = ds.Tables[0];
       
       //Or you can use
       //dataGridView1.DataSource = ds.Tables[0].DefaultView;    
       
       }
       catch (Exception ex)
       {
        MessageBox.Show(ex.Message.ToString());
       }
       finally
       {
       cn.Close();
       da.Dispose();
       ds.Dispose();
       cmd.Dispose();
      }
      }
