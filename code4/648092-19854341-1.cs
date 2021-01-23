        [DataMember]
        [JsonProperty("userInteractions", TypeNameHandling = TypeNameHandling.Auto)]
        public List<IUserInteraction> UserInteractions
        {
            get;
            set;
        }
