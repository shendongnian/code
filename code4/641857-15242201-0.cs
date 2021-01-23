    protected void btn_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        DataListItem di = btn.NamingContainer as DataListItem;
        FileUpload fu = di.FindControl("fu") as FileUpload;       
        if (fu.HasFile)
        {
         // save to the database :
         
        }
    }
