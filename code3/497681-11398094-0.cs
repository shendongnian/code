    public class Foo
    {
      public string Field1 {get; private set;}
      public string Field2 {get; private set;}
    
       public override string ToString()
       {
          return string.Format("Field1 = {0} , Field2 = {1}", Field1, Field2);
       }
    }
