    public class Article
    {
        //can be immutable
        public MagazineIssueView Issue { get; set; }
        public string Author { get; set; }
        public IList<Section> Sections { get; set; }
        public IList<Image> GetAllArticleImages()
        {
            return Sections
                .SelectMany<Section, ContentBlock>(s => s.SectionContent)
                .Where(c => c is Image)
                .Cast<Image>()
                .ToList();
        }
    }
    public class MagazineIssueView
    {
        public long ISBN { get; set; }
        //if you have internal Magazines list, it can be also internal MagazineId
        public string MagazineName { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueNumber { get; set; }
    }
    public class Section
    {
        public string SectionTitle { get; set; }
        public int Order { get; set; }
        public IList<ContentBlock> SectionContent { get; set; }
    }
    public abstract class ContentBlock
    {
    }
    public class Image: ContentBlock
    {
    }
    public class Paragraph: ContentBlock
    {
    }
