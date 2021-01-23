    public class Book
    {
         public string Title {get;set;}
         public DateTime PublicationDate {get;set;}
         public decimal Cost {get;set;}
         public virtual Author {get;set;}
    }
    
    public class Author
    {
         public string Name {get;set;}
         public DateTime DateOfBirth {get;set;
    }
