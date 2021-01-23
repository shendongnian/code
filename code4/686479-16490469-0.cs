    public class SomeClass 
    {
      public string Name {get;set;}
      public List<KeyValuePair<string, string>> ChildValues {get;set;}
    }
    
    var myItems = new List<SomeClass> { 
     new SomeClass { Name = "Item 1"}, 
     new SomeClass { Name = "Item 2"}, 
     new SomeClass { 
                      Name = "Item 3", 
                      ChildValues = new List<KeyValuePair<string, string>> 
                             { 
                               new KeyValuePair("SubKey1", "SubValue1"), 
                               new KeyValuePair("SubKey2", "SubValue2") 
                             } 
                    }
    };
    foreach (var item in myItems) 
    {
      Console.WriteLine(item.Name);
      if (item.ChildValues != null) 
      {
          item.ChildValues.Each(i=>Console.WriteLine("\t{0}:{1}", i.Key, i.Value);
      }
    }
