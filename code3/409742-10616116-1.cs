    OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\KUTTY\Real_Project\Royalty_Pro\DbRoyalty_Access\Buzz_Loyalty.mdb");
    DataSet ds = new DataSet();
    con.Open();
    OleDbCommand cmd = new OleDbCommand("select pic from test_table where id_image='123'",con);
    OleDbDataAdapter da=new OleDbDataAdapter(cmd);
    da.Fill(ds,"test_table");
    //con.Close();
    
    //ds = new DataSet();
    //da.Fill(ds, "test_table");
    FileStream FS1 = new FileStream("image.jpg", FileMode.Create);
    if (ds.Tables["test_table"].Rows.Count > 0)
    {
    	byte[] blob = (byte[])ds.Tables["test_table"].Rows[0]["pic"];
    	FS1.Write(blob, 0, blob.Length);
    	FS1.Close();
    	FS1 = null;
    
    	byte[] imageData = (byte[])cmd.ExecuteScalar();
    	MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length);
    	pictureBox2.Image = Image.FromStream(ms);
    	
    
    	
    	pictureBox2.Image = Image.FromFile("image.jpg");
    	pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
    	pictureBox2.Refresh();
    
    	pictureBox2.Image = Image.FromStream(new MemoryStream(blob));  
    	pictureBox2.Image = Image.FromFile("image.jpg");
    	pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
    	pictureBox2.Refresh();
    }
