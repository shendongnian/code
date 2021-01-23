    Lesson aLesson = new Lesson();
    aLesson.LessonID = Convert.ToInt32(DropDownList1.SelectedValue);
    aLesson.Period = period1.Text;
    aLesson.StartTime = time1.Text;
    aLesson.Weekday = "1";
    aLesson.CourseID = Convert.ToInt32(Scourses1.SelectedValue);
    aLesson.TeacherID = Convert.ToInt32(Steacher1.SelectedValue);
    aLesson.EndTime = time2.Text;
    myLessons.Add(aLesson); 
    // Repeat for the next block of fields
