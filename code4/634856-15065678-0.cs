    public DataTable Do_Insert_Update_Delete(string Proc_name, params object[] arg)
    {
        if (Proc_name == "Vehicle_Booked_Info")
        {
            SqlCommand com = new SqlCommand("Vehicle_Booked_Info", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(" @Today_Date", SqlDbType.DateTime).Value = Convert.ToDateTime(arg[0].ToString());
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
    
        }       
    
        return new DataTable();// or return null
    
    
    }
