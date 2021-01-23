    using ServiceStack.Text;
    public class user_new_register
    {
        public string ErrorStatus { get; set; }
        public string[] ErrorMessages { get; set; }
        public int UserID { get; set; }
        public static user_new_register FromJson(string json)
        {
            return JsonSerializer.DeserializeFromString<user_new_register>(json);
        }
    }
