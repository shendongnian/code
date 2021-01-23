    public abstract class Person
    {
       public string Name { get; set; }
       public string Surname { get; set; }
    
    }
    
    public class PersonCreateVM : Person
    {
       //no PersonId here
    }
    
    public class PersonEditVM : Person
    {
       public int PersonId{ get; set; }
    }
