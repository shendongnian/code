    if (student.UUID == AppliedStudent)
    {
        DataGridViewRow row = new DataGridViewRow();
        row.SetValues(new object[] { lesson.Name, Course.Course_Name, lesson.Level, lesson.Time, Teacher.C_Name, lesson.Price, Classroom.Classroom_Name });
        row.DefaultCellStyle.BackColor = Color.LightGreen;
        row.DefaultCellStyle.SelectionBackColor = Color.SkyBlue;
        dataGridView1.Rows.Add(row);
    }
