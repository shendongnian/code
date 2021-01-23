    private readonly SqlConnection m_oConn = new SqlConnection("ConnectionString");
    private readonly SqlCommand m_oCmd;
    
    m_oCmd = new SqlCommand("sp_password", m_oConn) { CommandType = CommandType.StoredProcedure };
    
    m_oCmd.Parameters.AddWithValue("@old", null);
    m_oCmd.Parameters.AddWithValue("@new", "newpassword");
    m_oCmd.Parameters.AddWithValue("@loginame", "username");
    
    var da = new SqlDataAdapter { SelectCommand = m_oCmd };
    
    var ds = new DataSet();
    da.Fill(ds);
