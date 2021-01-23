     public class Base {
          public void CommonMethod() { }
     }
     public class First : Base
     {
     }
     public class Second : Base
     {
     }
     var first = new First();
     first.CommonMethod();
     var second = new Second();
     second.CommonMethod();
