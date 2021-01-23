    public static IEnumerable<JObject> GetUsers(IEnumerable<string> usersUids, Field fields)
    {
        var tasks = usersUids.Select(
            uid =>
            {
                var parameters = new NameValueCollection
                {
                    {"uids", uid},
                    {"fields", FieldsUtils.ConvertFieldsToString(fields)}
                };
                return GetUser(parameters);
            }
        ).ToArray();
    
        Task.WaitAll(tasks);
    
        var result = new JObject[tasks.Length];
        for (var i = 0; i < tasks.Length; ++i)
            result[i] = tasks[i].Result;
    
        return result;
    }
