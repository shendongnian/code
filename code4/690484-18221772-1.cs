        CourseDetail course = e.Row as CourseDetails;
        if (e.IsGetData)
        {
            e.Value = course.StudentList.Where(s => s.Name == e.Column.Tag.ToString()).Count();  
        }
