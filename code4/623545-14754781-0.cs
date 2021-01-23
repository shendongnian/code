    public class MyClone : ICloneable
    {
        public object Clone()
        {
 	        return this.MemberwiseClone();
        }
    }
