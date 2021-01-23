    public class TextDocument
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public virtual List<Paragraph> Paragraphs { get; set; }
    }
    public class Paragraph
    {
       public virtual TextDocument Document { get; set; } 
       public int Order { get; set; }
       public string Text { get; set; }
       public virtual List<Image> Images { get; set; }
    }
    public class Image
    {
        public virtual Paragraph Paragraph {get; set; }
        public string Url { get; set }
    }
