    public class BaseClass
    {
      protected void SomeMethod()
       {
    
       }
    }
    public class ChildClass:BaseClass
    {
      public void SomeMethodPublic()
            {
              base.SomeMethod()
            }
    }
