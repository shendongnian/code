    public string FirstUserNickname(string JsonUserInfo) 
    {
        JavaScriptSerializer JsonSerializer = new JavaScriptSerializer();
        ResultData Results = JsonSerializer.Deserialize<ResultData>(JsonUserInfo);
        foreach (UserInfo UserInfo in Results.result)
        {
            if (string.IsNullOrEmpty(UserInfo.nickname))
                return UserInfo.nickname;
        }
        return null;
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
