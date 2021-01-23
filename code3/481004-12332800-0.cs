    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string full_name { get; set; }
        public string profile_picture { get; set; }
        public string bio { get; set; }
        public string website { get; set; }
        public Counts counts { get; set; }
        public static User SingleFromJSON(string jsonString)
        {
            return JsonConvert.DeserializeObject<SingleUser>(jsonString).data;
        }
        public static User MultipleFromJSON(string jsonString)
        {
            return JsonConvert.DeserializeObject<SingleUser>(jsonString).data;
        }
        private class SingleUser
        {
            public User data { get; set; }
        }
        private class MultipleUsers
        {
            public List<User> data { get; set; }
        }
    }
    public class Counts
    {
        public int media { get; set; }
        public int follows { get; set; }
        public int followed_by { get; set; }
    }
