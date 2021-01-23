       OleDbCommand comm = new OleDbCommand();
       comm.CommandType = CommandType.Text;
       comm.CommandText = @"insert into Student(Lastname, Firstname, Middlename) 
                                     values (@Lastname, @Firstname, @Middlename)"; 
       comm.Parameters.AddWithValue("@Lastname", txtlastname.Text);
       comm.Parameters.AddWithValue("@Firstname", txtfirstname.Text);
       comm.Parameters.AddWithValue("@Middlename", txtmiddlename.Text);
       comm.Connection = mydatabase;
