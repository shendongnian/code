    OleDbCommand system = new OleDbCommand();
    system.CommandType = CommandType.Text;
    system.CommandText = "DELETE FROM Student WHERE ID = ?";
    OleDbParameter parameter = new OleDbParameter("ID", txtStudentIDnumber.Text);
    system.Parameters.Add(parameter);
    system.Connection = mydatabase;
    mydatabase.Open();
    system.ExecuteNonQuery();
    dataGridView1.Update();
