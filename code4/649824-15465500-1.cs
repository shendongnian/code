    public class AssignmentContentItem
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Qty")]
        public int Quantity { get; set; }
        public AssignmentContentItem()
        {
            this.Quantity = 1;
        }
    }
