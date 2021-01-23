    public class SaveData : ICloneable
    {
        public double save_property1;
        public double save_property2;    
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
