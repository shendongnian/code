    public class Spec<T> where T : IComparable<T>
    {
        public Spec()
        {
            Min = default(T);
            Max = default(T);
        }
        public T Min { get; set; }
        public T Max { get; set; }
        public bool inSpec(T Value)
        {
            if(Value.CompareTo(this.Max) <=0 &&
                Value.CompareTo(this.Min) >=0)
                return true;
            else
                return false;
        }
        public Spec<T> Copy()
        {
            return (Spec<T>)this.MemberwiseClone();
        }
    }
