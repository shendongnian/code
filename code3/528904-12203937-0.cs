    public class Person
    {
         public Person(string name,string email)
         { 
             Name=name;
             Email=email;
         }
         public string Name {get;set;}
         public string Email {get;set;}
    }
    List<Person> people = {new Person("name1","test1@gmail.com"
                          ,new Person("name2","test2@gmail.com"
                          ,new Person("name3","test3@gmail.com"
                          ,new Person("name4","test4@gmail.com")};
