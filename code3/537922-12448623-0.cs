    public void add_student(string regNo,string fname, string lname, string phoneNo)
    {
         if (conn.State == ConnectionSate.Closed)          
                conn.Open();         
         SqlCommand newCmd = conn.CreateCommand();
         newCmd.CommandText = "insert into student values('" + regNo + "','" + fname + "','" + lname + "','" + phoneNo + "')";
         newCmd.ExecuteNonQuery();
    }
