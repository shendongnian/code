    [DataContract]
    public class Scores
    {
        [JsonProperty(PropertyName = "id")]
        [DataMember]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "UserName")]
        [DataMember]
        public string UserName { get; set; }
...
                    await scoresTable.InsertAsync(new Scores
                            {
                                UserName = _userName,
                                Score = (int) Score
                            });
