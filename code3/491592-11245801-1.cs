    public class Person
    {
      public string Name;
      public int Age;
    }
    
    p.Name = "Stacey"; p.Age = 30;
    
    //serialize
    XmlSerializer xs = new XmlSerializer (typeof (Person));
    
    using (Stream s = File.Create ("person.xml"))
      xs.Serialize (s, p);
    
    //deserialize
    Person p2;
    using (Stream s = File.OpenRead ("person.xml"))
      p2 = (Person) xs.Deserialize (s);
    
    Console.WriteLine (p2.Name + " " + p2.Age);   // Stacey 30
