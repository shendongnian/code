    public string[] GroupByUserType()
    {
        using (DataBase db = new DataBase ())
        {
            var query = from e in db.Users
                        group db.Users by e.UserType;
            string[] groups;
            List<string> groupsByUserType = new List<string>();
            foreach (var name in query)
            {
                foreach (var item in name["name"])
                {
                    groupsByUserType.Add(item);<--- error here
                }
            }
            groups = groupsByUserType.ToArray();
            return groups;
        }
    }
