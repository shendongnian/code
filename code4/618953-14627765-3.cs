    cmdRoute.CommandText = "SELECT id, name FROM routes";
    using (var rdrRoute = cmdRoute.ExecuteReader())
    {
        if(rdrRoute.Read())
        {
            var route = new Route();
            route.Id  = rdrRoute["id"];
            if (!string.IsNullOrEmpty(rdrRoute["name"].ToString()))
            {
               route.Name = rdrRoute["name"].ToString();
            }
        }
    }
