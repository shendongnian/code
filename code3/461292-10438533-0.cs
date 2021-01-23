    public class WebEnum
    {
         protected WebEnum(int value)
         {
             ...
         }
         private static WebEnum _member1 = new WebEnum(1);
         public static WebEnum Member1
         {
             get { return _member1; }
         }
    }
