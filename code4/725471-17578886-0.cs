    public class MyState   
    {
       private static MyState _intance = new MyState();
       public static MyState Instance 
       {
          return _instance;
       }
       private MyState() {}
       public bool IsChecked1 { get; set; }
