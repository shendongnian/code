    SqlConnection GetConnection() 
    { 
        return new SqlConnection(); 
    }
    void foo()
    {
        using (var cnx = GetConnection()) 
        { 
            cnx.Open();
        }
    }
