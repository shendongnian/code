     command.CommandText = "INSERT INTO tblUsersAccount (Username,[Password],Firstname,     MiddleName, Lastname,Birthday,ContactNo,DateCreated,DateModified) values (@Username,@Password,@Firstname,@MiddleName,@Lastname,@Birthday,@ContactNo,@DateCreated,@DateModified)";
    
    command.Parameters.Add("@Username", OleDbType.Char).Value = tbUsername.Text;
    command.Parameters.Add("@Password", OleDbType.Char).Value = tbPassword.Text;
    command.Parameters.Add("@Firstname", OleDbType.Char).Value = tbFirstname.Text;
    command.Parameters.Add("@MiddleName", OleDbType.Char).Value = tbMiddleName.Text;
    command.Parameters.Add("@Lastname", OleDbType.Char).Value = tbLastname.Text;
    command.Parameters.Add("@Birthday", OleDbType.Date).Value =DateTime.Parse(tbBirthday.Text).Date;//<---
    command.Parameters.Add("@ContactNo", OleDbType.Char).Value = tbContactNo.Text;
    command.Parameters.Add("@DateCreated", OleDbType.Date).Value = DateTime.Now.Date; //<---
    command.Parameters.Add("@DateModified", OleDbType.Date).Value = DateTime.Now.Date;//<---
