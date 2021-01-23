    while(dr.Read()) {
        string user = dr[0].ToString();
        string pass = dr[1].ToString();
        if(!String.IsNullOrWhiteSpace(user) && !String.IsNullOrWhiteSpace(pass)) 
           CreateUser(user, pass)
    }
    dr.Close()
