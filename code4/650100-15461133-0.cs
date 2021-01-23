    public class QuestionModel
    {
        //....
        public ICollection<TagModel> Tags { get; set; }
    }
    public class TagModel
    {
        //....
        public ICollection<QuestionModel> Questions { get; set; }
    }
