    int subjectVal;
    if(TryParse(ddlSubjects.SelectedValue, out subjectVal)
    {
        PopulateStudent(subjectVal, yearVal);
    }
    else
    {
        //Invalid value.  Log something, throw error, whatever.
    }
