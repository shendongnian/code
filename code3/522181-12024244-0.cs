    List<string>items=new List<string>();
    using (var con= new SqlConnection("yourConnectionStringHere")
    {
        string qry="SELECT Column1 FROM Table1" 
        var cmd= new SqlCommand(qry, con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        using (SqlDataReader objReader = cmd.ExecuteReader())
        {
            if (objReader.HasRows)
            {              
                while (objReader.Read())
                {
                  //I would also check for DB.Null here before reading the value.
                   string item= objReader.GetString(objReader.GetOrdinal("Column1"));
                   items.Add(item);                  
                }
            }
        }
    }
