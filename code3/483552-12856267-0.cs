        if (FileUpload1.HasFile)
        {
            byte[] img = new byte[FileUpload1.PostedFile.ContentLength];
            HttpPostedFile myimage = FileUpload1.PostedFile;
            myimage.InputStream.Read(img, 0, FileUpload1.PostedFile.ContentLength);
            SqlCommand cmd = new SqlCommand("insert into images values ('" + TextBox1.Text + "','" + FileUpload1.PostedFile + "')", con);
            con.Open();
