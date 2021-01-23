    public int Insert_LogBook(string Vehicle_Number, DateTime Vehicle_Booking_Date, TimeSpan Time_From, TimeSpan Time_To, int KM_Start, int KM_End, string Vehicle_Used_By, string Cost_Code, string Budget_Line, DateTime Entry_Date)
    {
        using(SqlCommand com = new SqlCommand("Insert_LogBook", con))
        {
            com.Parameters.Add("@Vehicle_Number", SqlDbType.NVarChar, 100).Value = Vehicle_Number;
            com.Parameters.Add("@Vehicle_Booking_Date", SqlDbType.DateTime).Value = Vehicle_Booking_Date;
            com.Parameters.Add("@Time_From", SqlDbType.Time).Value = Time_From;
            com.Parameters.Add("@Time_To", SqlDbType.Time).Value = Time_To;
            com.Parameters.Add("@KM_Start", SqlDbType.Int).Value = KM_Start;
            com.Parameters.Add("@KM_End", SqlDbType.Int).Value = KM_End;
            com.Parameters.Add("@Vehicle_Used_Byr", SqlDbType.VarChar, 100).Value = Vehicle_Used_By;
            com.Parameters.Add("@Cost_Code", SqlDbType.NVarChar, 50).Value = Cost_Code;
            com.Parameters.Add("@Budget_Line", SqlDbType.NVarChar, 50).Value = Budget_Line;
            com.Parameters.Add("@Entry_Date", SqlDbType.DateTime).Value = Entry_Date;
            con.Open();
            int res = com.ExecuteNonQuery();
         
            return 1;
        }
    
    }
    public void SomeMethodWhichUsesThatInsert()
    {
        try
        {
            //call Insert_LogBook
        }
        catch(SomeException e)
        {
            //handle
        }
    
    }
