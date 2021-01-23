    bool subjectsFound;
    if (data != null)
    {
        ddlSubjects.DataSource = data;
        ddlSubjects.DataValueField = "SubjectID";
        ddlSubjects.DataTextField = "SubjectCode";
        ddlSubjects.DataBind();
        subjectsFound = true;
    }
    else
    {
        lblAdd.Text = "No records found!";
        subjectsFound = false;
    }
