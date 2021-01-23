    protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        grd.Rows[e.RowIndex].FindControl("Control of the file Name"); 
        //Find control that contains file Name
        if (System.IO.File.Exists("FilePath"))
        {
            File.Delete(Path.Combine("path", "FileName"));
        }
        //Your Delete Code to delete record from database
    }
    
    protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        grd.Rows[e.RowIndex].FindControl("Control of the file Name"); 
        //Find control that contains file Name
        if (System.IO.File.Exists("FilePath"))
        {
            File.Delete(Path.Combine("path", "FileName"));
        }
        //Your Delete Code to delete record from database
    }
