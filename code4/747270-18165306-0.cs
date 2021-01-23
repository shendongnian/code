    public interface IArticle<T> where T : struct
    {
        T ConditionStatus { get; set; }
    }
    public class ArticleA : IArticle<ColorEnum>
    {
        public ColorEnum ConditionStatus { get; set; }
    }
    public class ArticleB : IArticle<PunctuationEnum>
    {
        public PunctuationEnum ConditionStatus { get; set; }
    }
