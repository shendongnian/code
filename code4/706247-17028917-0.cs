    static int getCount(DataTable dt, string name)
    {
        var user = dt.AsEnumerable()
                     .FirstOrDefault(p => p.Field<string>("username") == name);
        if (user != null)
            return Convert.ToInt32(user.Field<string>("count"));
        // return default value or raise exception
    }
