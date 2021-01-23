    using(SqlCeConnection Con = new SqlCeConnection("Data Source = 'Database.sdf';" + 
                                                    "Password='Password';")
    { 
        Con.Open(); 
        SqlCeCommand Query = new SqlCeCommand("INSERT INTO Users " + 
                                 "(Name,FName,Address,MCode,MNum,Amount) " +
                                 "VALUES (@Name,@FName,@Address,@Code,@Num,@Amount)",Con); 
    
        Query.Parameters.AddWithValue("@Name", NBox.Text);
        Query.Parameters.AddWithValue("@FName", SOBox.Text)); 
        Query.Parameters.AddWithValue("@Address",AdBox.Text)); 
        Query.Parameters.AddWithValue("@Code", Convert.ToInt32(MCode.Text));
        Query.Parameters.AddWithValue("@Num", Convert.ToInt32(MNum.Text));
        Query.Parameters.AddWithValue("@Amount" , Convert.ToInt32(AmBox.Text));
        Query.ExecuteNonQuery(); 
    }
