        [DefaultValue("Insert DefaultValue Here")]
        [Required]     /// <--- NEW
        public string Director { get; set; }
        // Example of default value sql
        [DefaultValue(DefaultValueSql: "GetDate()")]
        [Required]
        public string LastModified { get; set; }
