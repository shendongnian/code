    [Serializable] 
    public class ReviewerBag {
        public Dictionary<string, Reviewer> Reviewers { get; set; }
        public string Moderator { get; set; }
        public ReviewerBag()
        {
            Reviewers = new Dictionary<string,Reviewer>();
        }
        ...
    }
