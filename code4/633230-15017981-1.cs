    public List<Person> getAllPeople()
    {
       var people = new List<People>();
    
       try
       {
           using (SqlCommand com = new SqlCommand("SELECT * FROM USERS", con))
           {
               con.Open();
    
               SqlDataReader sql = com.ExecuteReader();
    
               while (sql.Read())
               {
                   people.Add(new Person
                              {
                                  ID = sql.GetInt32(0), 
                                  FirstName = sql.GetString(1),
                                  LastName = sql.GetString(2),
                                  Age = sql.GetInt32(3) ,
                                  School = sql.GetString(4)
                              });
               }
            }
        } 
