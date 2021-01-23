    public class MyClonableClass : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
