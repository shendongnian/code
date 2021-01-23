    var users = GetFromDb<string,User>(reader => {
        string key;
        Users user = new Users();
        user.ID = reader.GetInt32(0);
        user.type = reader.GetString(1).Trim();
        key = reader.GetString(2).Trim();
        user.nick = key;
        user.password = reader.GetString(3).Trim();
        user.fName = reader.GetString(4).Trim();
        user.lName = reader.GetString(5).Trim();
        user.identify = reader.GetString(6).Trim();
        user.email = reader.GetString(7).Trim();
        user.address = reader.GetString(8).Trim();
        user.registerDate = reader.GetString(9).Trim();
        user.localOrInDb = "inDatabase";
        return new KeyValuePair<string,User>(key, user);
    });
