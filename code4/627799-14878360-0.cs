    public class Paragraph
    {
       public int Id {get; set;} // add this
       public virtual List<Images> Images {get; set;} // and add this
       public virtual TextDocument Document { get; set; } 
       public int Order { get; set; }
       public string Text { get; set; }
    
    }
