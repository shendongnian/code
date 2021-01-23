    List<Prod> prodRows = new List<Prod>();
    while (reader.Read())
    {
         prodRows.Add(new Prod 
         { 
             Prod_Type = reader.GetValue(0),
             Prod_N = reader.GetValue(1),
             Prod_d = reader.GetValue(2)
          });
     }
