    cmdRoute.CommandText = "SELECT id, name FROM routes";
    using (var rdrRoute = cmdRoute.ExecuteReader())
    {
        if(rdrRoute.Read())
        {
            var route = new Route();
            route.Id = rdrRoute.GetInt32(0);
            route.Name = (string)rdrRoute.GetString(1);
        }
    }
   
