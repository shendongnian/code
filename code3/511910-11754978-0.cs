    if (dr1.Read())
    {
        employer_epf = Convert.ToDouble(dr1[0].ToString()); 
        if (dr1.Read())
        {
            employer_admin = Convert.ToDouble(dr1[0].ToString()); 
            // etc...
        }
    }
