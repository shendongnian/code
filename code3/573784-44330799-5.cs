    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            DataTable dt = ExcelToDataTable(FileUpload1.FileBytes, CheckBox1.Checked);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
