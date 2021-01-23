    try
    {
    	SqlConnection cn = new SqlConnection(strCn);
    	cn.Open();
    
    	//Retrieve BLOB from database into DataSet.
    	SqlCommand cmd = new SqlCommand("SELECT BLOBID, BLOBData FROM BLOBTest ORDER BY BLOBID", cn);	
    	SqlDataAdapter da = new SqlDataAdapter(cmd);
    	DataSet ds = new DataSet();
    	da.Fill(ds, "BLOBTest");
    	int c = ds.Tables["BLOBTest"].Rows.Count;
    
    	if(c>0)
    	{   //BLOB is read into Byte array, then used to construct MemoryStream,
    		//then passed to PictureBox.
    		Byte[] byteBLOBData =  new Byte[0];
    		byteBLOBData = (Byte[])(ds.Tables["BLOBTest"].Rows[c - 1]["BLOBData"]);
    		MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
    		pictureBox1.Image= Image.FromStream(stmBLOBData);
    	} 
    	cn.Close();
    }
    catch(Exception ex)
    {MessageBox.Show(ex.Message);}
