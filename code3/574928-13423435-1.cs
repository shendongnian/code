    public class LogOnViewModel
        {
            [LocalizedDisplayNameAttribute("username", typeof(MyLabels.labels))]
            [Required]
            public string UserName { get; set; }
            [LocalizedDisplayNameAttribute("password", typeof(MyLabels.labels))]
            [Required]
            public string Password { get; set; }
        }
    
        public class FTPViewModel
        {
            [LocalizedDisplayNameAttribute("username", typeof(MyLabels.labels))]
            [Required]
            public string ftpUserName { get; set; }
            [LocalizedDisplayNameAttribute("password", typeof(MyLabels.labels))]
            [Required]
            public string ftpPassword { get; set; }
        }
