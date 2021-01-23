        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        [RegularExpression(@"(?i)^(http[s]?://|\\\\).+$", ErrorMessage = "Not good website")]
        public string Website { get; set; }
