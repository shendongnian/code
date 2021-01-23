    protected void Button1_Click(object sender, EventArgs e)
    {
        string Img_name = FileUpload1.FileName;
        string folder_path = Server.MapPath("~\\userimages\\");
        FileUpload1.SaveAs(folder_path + Img_name);
    }
