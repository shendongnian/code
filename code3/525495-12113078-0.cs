    public static string Serialize(StringDictionary data)
    {
        if(data == null) return null; // GIGO
        DbConnectionStringBuilder db = new DbConnectionStringBuilder();
        foreach (string key in data.Keys)
        {
            db[key] = data[key];
        }
        return db.ConnectionString;
    }
    public static StringDictionary Deserialize(string data)
    {
        if (data == null) return null; // GIGO
        DbConnectionStringBuilder db = new DbConnectionStringBuilder();
        StringDictionary lookup = new StringDictionary();
        db.ConnectionString = data;
        foreach (string key in db.Keys)
        {
            lookup[key] = Convert.ToString(db[key]);
        }
        return lookup;
    }
