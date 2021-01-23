       OleDbCommand comm = new OleDbCommand();
       comm.CommandType = CommandType.Text;
       comm.CommandText = 
           @"insert into Student(StudentIdNo, Lastname, Firstname, Middlename) 
                         values (@StudentIdNo, @Lastname, @Firstname, @Middlename)"; 
       comm.Parameters.AddWithValue("@StudentIdNo", txtStudentIdNo.Text);
       comm.Parameters.AddWithValue("@Lastname", txtlastname.Text);
       comm.Parameters.AddWithValue("@Firstname", txtfirstname.Text);
       comm.Parameters.AddWithValue("@Middlename", txtmiddlename.Text);
       comm.Connection = mydatabase;
