    if (item.LectureName == DrpdwnLectureName.SelectedValue)
    {
        var list = client.GetStudentQuestions(item.LectureID, user);
        if (list.Count() > 0)
        {
            rptStudentQuestion.Visible = true;
            rptStudentQuestion.DataSource = list;
            rptStudentQuestion.DataBind();
        }
        else
        {
            rptStudentQuestion.Visible = false; // In debug it preforms this, but nothing happens.     
            UpdatePanel1.Update() //This 'force' updatepanel updating        
        }
    }
