    SortedList UserList = new SortedList();
    
    List<double> listofUserIDs = StatsTable.AsEnumerable()
    .Select(uid => uid.Field<double>("UserID")).ToList<double>();
    foreach (double UID in listofUserIDs)
    {
        string userName = UserTable.AsEnumerable()
            .Where(id => double.Equals(id.Field<double>("UserID"), UID))
        .Select(name => name.Field<string>("First_Name") + " " + name.Field<string>("Last_Name")).FirstOrDefault().ToString();
    
         UserList[UID] = userName;
    }
