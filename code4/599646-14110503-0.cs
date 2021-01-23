    Student StudentInfo = new Student
    {
         StudentName = textBox.Text.ToString(),
         StudentDate = (DateTime)datePicker1.Value;
    };
    db.StudentInfo.InsertOnSubmit(newStudent);
    db.SubmitChanges();
