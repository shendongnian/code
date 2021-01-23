    string sqlCommand = "INSERT INTO table1 (FirstName, LastName) VALUES (@fName, @lName)";
    SQLiteParameter[] p = new SQLiteParameter[2];
    p[0] = new SQLiteParameter("@fName", TextBox1.Text);
    p[1] = new SQLiteParameter("@lName", TextBox2.Text);
    int rowAdded = MyHelperClass,InsertCommand(sql, p);
