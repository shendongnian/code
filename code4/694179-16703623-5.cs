    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
        {
    
            byte[] myimage = new byte[FileUpload1.PostedFile.ContentLength];
            HttpPostedFile Image = FileUpload1.PostedFile;
            Image.InputStream.Read(myimage, 0, (int)FileUpload1.PostedFile.ContentLength);
    
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AsianConnectionString"].ConnectionString);
    
            SqlCommand storeimage = new SqlCommand("dbo.MyProc", myConnection);
            if (myimage != null) { storeimage.Parameters.Add("@image", SqlDbType.VarBinary, myimage.Length).Value = myimage; }
            if (!string.IsNullOrEmpty(FileUpload1.PostedFile.ContentType)) { storeimage.Parameters.Add("@imagetype", SqlDbType.VarChar, 100).Value = FileUpload1.PostedFile.ContentType; }
            if (FileUpload1.PostedFile.ContentLength > 0) { storeimage.Parameters.Add("@imagesize", SqlDbType.BigInt, 99999).Value = FileUpload1.PostedFile.ContentLength; }
            storeimage.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = lblSelection.Text;
            storeimage.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = TextBox2.Text;
            storeimage.Parameters.Add("@description", SqlDbType.NVarChar, 250).Value = TextBox3.Text;
            if (!string.IsNullOrEmpty(TextBox4.Text)) { storeimage.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = TextBox4.Text; }
            if (myimage != null) { storeimage.Parameters.Add("@userpicture", SqlDbType.VarBinary, myimage.Length).Value = myimage; }
            if (!string.IsNullOrEmpty(FileUpload2.PostedFile.ContentType)) { storeimage.Parameters.Add("@userpicturetype", SqlDbType.VarChar, 100).Value = FileUpload2.PostedFile.ContentType; }
            if (FileUpload2.PostedFile.ContentLength > 0) { storeimage.Parameters.Add("@userpicturesize", SqlDbType.BigInt, 99999).Value = FileUpload2.PostedFile.ContentLength; }
    
            try
            {
                myConnection.Open();
                storeimage.ExecuteNonQuery();
            }
            finally
            {
                myConnection.Close();
            }    
        }
    }
