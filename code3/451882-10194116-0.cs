    ds.Tables[0].Rows.AsEnumerable().AsParallel().Sum(x =>
      {
           DataRow dr = x as DataRow;
           switch(dr["Gender"].ToString())
           {
               case "Male":
                 // Stuff
               case "Female";
                 // Stuff
               default:
                 // Stuff
           }
           return counter;
      });
