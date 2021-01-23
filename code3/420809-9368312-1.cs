    public class BaseClass
    {
        public int MyProperty
        {
           get; set;
        }
    }
    public class ChildClass : BaseClass
    {
        public new int MyProperty
        {
           get
           {
               return base.MyProperty;
           }
           set
           {
               if(DoYourCheckingStuff(value))
               {
                   base.MyProperty = value;
               }
           }
        }
    }
