    public string YourFunction(string YourJsonInput) 
    {
        JavaScriptSerializer JsonSerializer = new JavaScriptSerializer();
        ResultData Results = JsonSerializer.Deserialize<ResultData>(YourJsonInput);
        foreach (UserInfo UserInfo in Results.result)
        {
            if (string.IsNullOrEmpty(UserInfo.nickname))
                return UserInfo.nickname;
        }
    }
    public class ResultData
    {
        public List<UserInfo> result;
    }
    public class UserInfo
    {
        public string bio;
        public string name;
        public string nickname;
    }
