     try
         {
           
             OleDbConnection conn = new OleDbConnection(("provider=Microsoft.Jet.OLEDB.4.0; " + ("data source=" + myInt + ";" + "Extended Properties=Excel 8.0;")));
        
             OleDbDataAdapter ada = new OleDbDataAdapter("SELECT * FROM [MarkingSheet$]", conn);
             
             DataSet ds = new DataSet();
        
             conn.Open();             
             ada.Fill(ds.Tables[0]);
             
             conn.Close();
             BindingSource bs = new BindingSource();
             bs.Datasource = ds.Tables[0];
             dataGridView1.DataSource = bs;
          }
      catch(OledbException x)
          {
            // Handle Exception
          }
