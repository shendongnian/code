    public class TrackedValue<T> : IChangeTracking
    {
        T trackedValue;
        public T Value
        {
            get
            {
                return this.trackedValue;
            }
            set
            {
                this.trackedValue = value;
            }
        }
    
        public static implicit operator T(TrackedValue<T> value)
        {
            return value.Value;
        }
    
        public static implicit operator TrackedValue<T>(T value)
        {
            return new TrackedValue<T>() { Value = value };
        }
    }
