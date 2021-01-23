    var dic = (from order in ds.Tables[0].AsEnumerable()
                       select new
                       {
                           UserView = order.Field<String>("Value"),
                           DevView = order.Field<String>("id")
                       }).AsEnumerable().ToDictionary(k => k.DevView, v => v.UserView);
