    namespace Json.CareerJsonTypes
    {
    
        internal class Act13
        {
    
            [JsonProperty("completed")]
            public bool Completed { get; set; }
    
            [JsonProperty("completedQuests")]
            public IList<CompletedQuest9> CompletedQuests { get; set; }
        }
    }
