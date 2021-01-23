    string json = "[{Name:'John Simith',Age:35},{Name:'Pablo Perez',Age:34}]"; 
    public class Person
    {
       public int Age {get;set;}
       public string Name {get;set;}
    }
    JavaScriptSerializer js = new JavaScriptSerializer();
    Person [] persons =  js.Deserialize<Person[]>(json);
