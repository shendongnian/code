    private bool uploadImage(ref Bitmap p)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Configuration.ConfigurationManager.ConnectionStrings("ConnStringHere").ConnectionString;
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "INSERT INTO Table_Name (File2) VALUES (@File2)"; //I named the column File2 simply because "File" seemed to be a keyword in SQLServer
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        SqlParameter File1 = new SqlParameter("@File2", SqlDbType.Image);
        MemoryStream ms = new MemoryStream();
        using (Bitmap tempImage = new Bitmap(p))
        {
            tempImage.Save(ms, p.RawFormat);
        }
        byte[] data = ms.GetBuffer();
        if (!isValidImage(data)) //optional, will include code if requested.
        {
            return false;
        }
        File1.Value = data;
        cmd.Parameters.Add(File1);
        con.Open();
        int result = cmd.ExecuteNonQuery();
        if (result > 0)
        {
            // SUCCESS!
            con.Close();
            return true;
        }
        else
        {
            //failure
            con.Close();
            return false;
        }
    }
