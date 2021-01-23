    DataTable dtCourse = new DataTable();
    dtCourse.Columns.Add("Course_ID");
    dtCourse.Columns.Add("Visibility");
    dtCourse.Rows.Add("1", "True"); // here
    dtCourse.Rows.Add("2", "False"); // here
    dtCourse.Rows.Add("3", "True"); // here
    lbl_CourseName.DataBindings.Add("Text", dtCourse, "Course_ID");
    btnViewExam.DataBindings.Add("Visible", dtCourse, "Visibility");
    dr_Course.DataSource = dtCourse;  
