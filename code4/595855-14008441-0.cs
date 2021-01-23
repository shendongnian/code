    public class MyViewModel {
        public string UserId { get; set; }
        public FulltimeJob FulltimeJob { get; set; }
        public InternJob InternJob { get; set; }
        public IJob Job { get { return FulltimeJob ?? InternJob; } }
    }
