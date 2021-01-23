    protected void AjaxFileUpload1_UploadComplete1(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)<br>
        {
            string filepath = (Server.MapPath("~/Images/") +Guid.NewGuid()+ System.IO.Path.GetFileName(e.FileName));<br>
            AjaxFileUpload1.SaveAs(filepath);<br>
            string fl = filepath.Substring(filepath.LastIndexOf("\\"));<br>
            string[] split = fl.Split('\\');<br>
            string newpath = split[1];<br>
            string imagepath = "~/Images/" + newpath;<br>
            string Insert = "Insert into IMAGE_PATH (IMAGE_PATH) values (@IMAGE_PATH)";<br>
            SqlCommand cmd = new SqlCommand(Insert, con);<br>
            cmd.Parameters.AddWithValue("@IMAGE_PATH", newpath);<br>
            con.Open();<br>
            cmd.ExecuteNonQuery();<br>
            con.Close();<br>
            cmd.Dispose();<br>
    
        }
