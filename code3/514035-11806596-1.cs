    SQlConnection con = new SqlConnection("Database connection string");
    public bool getAuthenticate(string UserName,string Password)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM tablename WHERE Fieldusername='" + UserName + "' AND Fieldpassword='" + Password + "'",con);
        SqlDataReader rd;
        rd = cmd.executeReader();
        if(rd.read())
        {
             con.Close();
             return true;
        }
        else
        {
             con.Close();
             return false;
        }
    }
