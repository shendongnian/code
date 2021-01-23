    cmdRoute.CommandText = "SELECT id, name FROM routes";
    using (var rdrRoute = cmdRoute.ExecuteReader())
    {
        if(rdrRoute.Read())
        {
            var route = new Route();
            route.Id  = rdrRoute["id"];
            if (!rdrRoute.IsDBNull(rdrRoute.GetOrdinal("name")))
            {
               //route.Name = rdrRoute["name"].ToString();
                route.Name = rdrRoute.GetString(rdrRount.GetOrdinal("name"))
            }
        }
    }
