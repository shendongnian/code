    protected void gridStudentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
     Student studentObj = (Student)StudentList[e.Row.RowIndex];
     if (studentObj != null)
      {
       DropDownList ddlMarks = (DropDownList)e.Row.FindControl("ddlMarks");
       if(ddlMarks != null)
       {
        ddlMarks.DataSource = studentObj.Marks;
        ddlMarks.DataBind();
       }
      }
     }
