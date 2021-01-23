    public class MyState   
    {
       private static MyState _instance = new MyState();
       public static MyState Instance 
       {
          get { return _instance; }
       }
       private MyState() {}
       public bool IsChecked1 { get; set; }
