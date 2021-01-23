    con.Open();
    string mysql; // generate an sql insert query for the database
    mysql = "SELECT 1 FROM [Users] UserName='" + tbUser.Text + "' AND 
             Password='"+ tbPass.Text+"'";
    OleDbCommand CheckUser = new OleDbCommand(mysql, con);
    int temp = Convert.ToInt32(CheckUser.ExecuteScalar());
    if(temp==1)
    {
     //Login
    }
    else
    {
     //Invalid UserName or Password.
    }
