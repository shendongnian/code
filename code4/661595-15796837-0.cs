    public class Parent
    {
      public string ID {get;set;}
      public string First {get;set;}
      public string Last {get;set;}
      public string Gender {get;set;}
      public List<string> ChildrensNames {get;set;}
    
      public Parent(XElement parentXML) { // parse XML and fill properties
      }
    
    }
