    List<Student> students = new List<Student>();
    private void btnAddStudent_Click(object sender, EventArgs e)
    {
        students.Add(Student(txtStudentName.Text, txtStudentSurname.Text,
                     int.Parse(txtExamMark.Text), counter);
        counter++;
    }
    private void btnAverage_Click(object sender, EventArgs e)
    {
        if(students.Any())
        {
            MessageBox.Show("" + students.Last().Average);
        }
    }
