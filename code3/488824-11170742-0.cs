        public String Id { get; set; }
        public String Name { get; set; }
        /// <summary>
        /// just a helper to get the first part of the userID
        /// </summary>
        public string IDPart1 { get { return Id.Split('/')[0]; } }
        /// <summary>
        /// just a helper to get the second part of the userID
        /// </summary>
        public string IDPart2 { get { return Id.Split('/')[1]; } }
    }
