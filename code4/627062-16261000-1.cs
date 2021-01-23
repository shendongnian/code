    public class TodoItem
    {
        public int Id { get; set; }
        // REMOVE WHAT YOU DO NOT WANT
        //[DataMember(Name = "text")]
        //public string Text { get; set; }
        [DataMember(Name = "complete")]
        public bool Complete { get; set; }
    }
