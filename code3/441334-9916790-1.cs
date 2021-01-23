    @functions {
       public class Person
       {
           public string Name { get; set; }
       }
    }
    @{
       var p = new Person();
    }
    
    <span>@p.Name</span>
