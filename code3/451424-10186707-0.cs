    if(HttpContext.Current.User.IsInRole("Level1"))
    {
        FilesGrid.Columns[1].Visible = true;
    }
    else
    {
        FilesGrid.Columns[1].Visible = false;
    }
