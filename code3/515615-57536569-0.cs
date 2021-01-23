    public class UserSettingsModel
    {
        public string UserName { get; set; }
        [IgnoreDataMember]
        public DateTime Created { get; set; }
    }
