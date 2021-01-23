    OleDbCommand command = new OleDbCommand(); 
 
    command.CommandText = "UPDATE tblUsersAccount SET [Password] = ?, Firstname = ?, " + 
                          "MiddleName = ?, Lastname = ?, Birthday = ?, ContactNo = ? " + 
                          "WHERE Username = ?"; 
 
    connect.ConnectionString = connectionString; 
    connect.Open(); 
    command.Connection = connect; 
 
    command.Parameters.Add("@Password", OleDbType.Char).Value = tbPassword.Text; 
    command.Parameters.Add("@Firstname", OleDbType.Char).Value = tbFirstname.Text; 
    command.Parameters.Add("@MiddleName", OleDbType.Char).Value = tbMiddleName.Text; 
    command.Parameters.Add("@Lastname", OleDbType.Char).Value = tbLastname.Text; 
    command.Parameters.Add("@Birthday", OleDbType.Date).Value =DateTime.Parse(tbBirthday.Text); 
    command.Parameters.Add("@ContactNo", OleDbType.Char).Value = tbContactNo.Text; 
    command.Parameters.Add("@Username", OleDbType.Char).Value = tbUsername.Text; 
    command.ExecuteNonQuery(); 
