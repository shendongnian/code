    //on Form Load set your connection string
    Conn = "..Your Connection String";
    MyClass.MyCon = Conn;
    
    //on event handler call your class
    string conSTR = MyClass.MyCon
    
    //this is your class
    public class MyClass
    {
      public static string iMyCon = "";
      
      public static string MyCon
      {
        get { return iMyCon; }
        set { iMyCon = value; }
      }
    }
