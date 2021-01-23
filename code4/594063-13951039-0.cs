    string userName = UserTable.AsEnumerable()
        .Where(id => double.Equals(id.Field<double>("UserID"), UID))
        .Select(name => name.Field<string>("First_Name") + " "
                      + name.Field<string>("Last_Name"))
        .Single();
