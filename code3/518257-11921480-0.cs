    public string selectname(string email) 
    { 
        string name; 
        using(SqlConnection con = new SqlConnection(constr))
        {
            string select = "SELECT studentlastname,studentfirstname,studentmiddleinitial " + 
                            "FROM STUD_DB WHERE emailaddress = @mail"; 
            SqlCommand sel = new SqlCommand(select, con); 
            sel.Parameters.Add("@mail", email);
            SqlDataReader dr = sel.ExecuteReader();
            while(dr.Read())
                name = string.Join(" ", dr.GetString(0), dr.GetString(1), dr.GetString(2));
        }
        return name;
    }
