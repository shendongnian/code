    protected void ajaxUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
    {
        id += 1;
        string filename = Path.GetFileName(e.FileName);
        string filepath = Server.MapPath("~/Images/Gallery/" + filename);
        ajaxUpload1.SaveAs(filepath);
        string Insert = "Insert into slider (slid,slurl) values (" + @id + ",'" + @IMAGE_PATH + "')"; 
        SqlCommand cmd = new SqlCommand(Insert, con);
        cmd.CommandType = CommandType.Text;
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
            cmd.Dispose();
        }
    }
