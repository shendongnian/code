    public void gridfill()
    {
        markSp spMark = new markSp();
        gvResult.DataSource = spMark.markViewBySchool(txtSchoolName.Text);
        gvResult.DataBind();  
    }
