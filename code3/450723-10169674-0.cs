    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ScriptIgnore]
        public bool IsComplete
        {
            get { return Id > 0 && !string.IsNullOrEmpty(Name); }
        }
    }
