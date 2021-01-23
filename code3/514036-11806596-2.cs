    SQlConnection con = new SqlConnection("Database connection string");
    const string uName="UserName";
    const string pWord="Password";
    public bool getAuthenticate(string UserName,string Password)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand(con);
        SQlParameter[] param=new SqlParameter[]{
             new SqlParamter(uName,UserName),
             new SqlParameter(pWord,Password)
        };
        cmd.Parameters.AddRanage(param);
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
