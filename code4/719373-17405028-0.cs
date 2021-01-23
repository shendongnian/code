    public class Model : ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
