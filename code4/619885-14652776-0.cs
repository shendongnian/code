    public partial class Post {
       public int Id {get;set;}
       public string Subject  {get;set;}
       public string Body {get;set;}
       public DateTime Date {get;set;}
       //etc.
       public virtual User Author {get;set;} //this is what's called a Navigation proeprty, which will help you to find relations with your User class.
    }
    public partial class User {
       public int Id {get;set;}
       public string Name {get;set;
    
       public IList<Post> Posts {get;set;}//Navigation property from User to Post class. It's a list, reflecting the one-to-many from Post to User.
    }
