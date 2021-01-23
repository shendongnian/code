    public class Base
    {
         public int SomeNumber { get; set; }
         public Base(int someNumber)
         {
             SomeNumber = someNumber;
         }
    }
    public class AlwaysThreeDerived : Base
    {
        public AlwaysThreeDerived()
           : base(3)
        {
        }
    }
