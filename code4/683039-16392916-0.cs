    public void gridfill()
    {
        markSp spMark = new markSp();
        DataTable dtbl = new DataTable();
        dtbl = spMark.markViewAll();
        gvResult.DataSource = dtbl;
        dtbl = spMark.markViewBySchool(txtSchoolName.Text);
        gvResult.DataSource = dtbl;    
        gvResult.DataBind(); // This is missing
    }
