      // create and open connection
      // change for your environment
      string connStr = "User Id=pm; Password=pm; Data Source=orcllx; Pooling=false";
      OracleConnection con = new OracleConnection(connStr);
      try
      {
        con.Open();
      }
      catch (OracleException ex)
      {
        MessageBox.Show(ex.Message);
      }
 
      // statement to get a blob
      string sql = "select ad_composite from print_media where product_id=3106 and
                   ad_id=13001";
 
      // create command object
      // InitialLOBFetchSize
      //  defaults to 0
      OracleCommand cmd = new OracleCommand(sql, con);
 
      cmd.InitialLOBFetchSize = 8192;
 
      // create a datareader
      OracleDataReader dr = cmd.ExecuteReader();
 
      // read the single row result
      try
      {
        dr.Read();
      }
      catch (OracleException ex)
      {
        MessageBox.Show(ex.Message);
      }
 
      // use typed accessor to retrieve the blob
      OracleBlob blob = dr.GetOracleBlob(0);
 
      // create a memory stream from the blob
      MemoryStream ms = new MemoryStream(blob.Value);
 
      // set the image property equal to a bitmap
      // created from the memory stream
      pictureBox1.Image = new Bitmap(ms);
