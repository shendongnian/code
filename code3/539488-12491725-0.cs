    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile != null)
        {
                string fileExt = 
                   System.IO.Path.GetExtension(FileUpload1.FileName);
    
                if (fileExt == ".jpeg" || fileExt == ".jpg")
                {
    
    string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
    
            //Save files to disk
            FileUpload1.SaveAs(Server.MapPath("~/_PublicData/Images/" + FileName));
    
            //Add Entry to DataBase
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["Computer_Klubben_CommunitySiteConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            string strQuery = "insert into dbo.Billeder (FileName, FilePath)" + " values(@FileName, @FilePath)";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.AddWithValue("@FileName", FileName);
            cmd.Parameters.AddWithValue("@FilePath", "~/_PublicData/Images/" + FileName);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
    
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
    
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
    
            finally
            {
                con.Close();
                con.Dispose();
            }
    
    
    }
    else
    {
      //Show Error Message. Invalid file.
    }
    
    
        }
    
    }
