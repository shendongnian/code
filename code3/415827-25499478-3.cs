    [Serializable]
    public class MyClass
    {
      public int a {get; set;}
      public int b {get; set;}
    }     
    var obj = new MyClass{
    a = 10,
    b = 20,
    };
    var newobj = Clone<MyClass>(obj);
