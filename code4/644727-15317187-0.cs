    public class MyClass {
    
      public int prop1 { get; set; }
      public string prop2 { get; set; }
      public int[] prop3 { get; set; }
      public int prop4 { get; set; }
      public string prop5 { get; set; }
      public string prop6 { get; set; }
    
      public ArrayList GetProperties() {
    
        Func<object>[] myProperties = {
          () => prop1, () => prop2, () => prop3,
          () => prop4, () => prop5, () => prop6
        };
    
        ArrayList myList = new ArrayList();
        foreach (var p in myProperties) {
          myList.Add(p());
        }
    
        return myList;
      }
    
    }
