    public static DataSet GetContactResultSetByLead(int leadID)
    {
        SqlCommand Sqlmd = new SqlCommand("dbo.proc_contact");
        Sqlmd.CommandType = CommandType.StoredProcedure;
        Sqlmd.Parameters.Add("@LeadInfoID", SqlDbType.Int).Value = leadID;
    
        Sqlmd.Connection = m_ConStr;
        SqlDataAdapter da = new SqlDataAdapter(Sqlmd);
    
        DataSet data = new DataSet();
        try
        {
            m_ConStr.Open(); //connection should be opened in order to fill the data
            da.Fill(data);
        }
    
        finally
        {
            m_ConStr.Close();
        }
    
        return data;
    }
