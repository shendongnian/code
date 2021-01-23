    public class Action : Attribute {
      public Keys HotKey {get;set;} 
    }
    [Action(HotKey = (Keys.Control | Keys.A))]
    public void MyMethod() {
      ...
    }
