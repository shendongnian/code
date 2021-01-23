    DataTable table = new DataTable();
    table.Columns.Add("StudentID", typeof(int));
    table.Columns.Add("StudenName", typeof(string));
    table.Columns.Add("Passed", typeof(bool));
    
    int studentID = int.Parse(txtStudentID.Text);
    String studentName = txtStudentName.Text;
    bool passed = ckbxPF.SelectedIndex == 0; // assuming that "passed" is the first item
    
    table.Rows.Add(studentID, studentName, passed);
