        [DataMember]
        [JsonProperty("stateEntries", TypeNameHandling = TypeNameHandling.Auto)]
        public List<IStateEntry> StateEntries
        {
            get;
            set;
        }
        [DataMember]
        [JsonProperty("precommitStateEntry", TypeNameHandling = TypeNameHandling.Auto)]
        public IPrecommitStateEntry PrecommitStateEntry
        {
            get;
            set;
        }
