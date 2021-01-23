    if(User.IsInRole("YourRole"))
    {
        GridView.Columns[0].Visible = true;
        GridView1.Columns[0].Enabled = true;
    }
    else{
        GridView1.Columns[0].Visible = false;
        GridView1.Columns[0].Enabled = false;
    }
