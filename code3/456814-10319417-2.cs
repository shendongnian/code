    private bool m_flag = false;
            private string strFirstName;
            private string strLastName;
    
            public string FirstName
            {
                get { return strFirstName; }
                set { strFirstName = value; }
            }
    
            public string LastName
            {
                get { return strLastName; }
                set { strLastName = value; }
            }
    public bool upDate(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                cmd.Parameters.AddWithValue("@Fname", FirstName);
                cmd.Parameters.AddWithValue("@Lname", LastName);
                cmd.CommandText = "Update tblTransaction1 set LastName=@Lname where FirstName=@Fname";
                if (cmd.ExecuteNonQuery() > 0)
                {
                    m_flag = true;
                }
            }
            catch
            {
            }
            return m_flag;
        }
