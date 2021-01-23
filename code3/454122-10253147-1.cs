    public class MyClonableClass
    {
        public MyClonableClass Clone()
        {
            return (MyClonableClass)this.MemberwiseClone();
        }
    }
