    public static IEnumerable<JObject> GetUsers(IEnumerable<string> usersUids, Field fields)
    {
        var results = new List<JObject>
        Parallel.ForEach(usersUids, uid => {
            var parameters = new NameValueCollection
                                 {
                                     {"uids", uid},
                                     {"fields", FieldsUtils.ConvertFieldsToString(fields)}
                                 };
            results.Add(GetUser(parameters).Result);
        });
        return results;
    }
