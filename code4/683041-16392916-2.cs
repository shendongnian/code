    public void gridfill()
    {
        markSp spMark = new markSp();
        DataTable dtbl = new DataTable();
        dtbl = spMark.markViewAll(); //you are not using this anywhere
        gvResult.DataSource = dtbl;  // so you can get rid of these two lines
        dtbl = spMark.markViewBySchool(txtSchoolName.Text);
        gvResult.DataSource = dtbl;    
        gvResult.DataBind(); // This is missing
    }
