    interface IHasValue
    {
        object Value { get; set; }
        void Increment();
        void Decrement();
    }
    interface IHasValue<TValue> : IHasValue { new TValue Value { get; set; } }
    abstract class UpDownValueControl<T> : IHasValue<T>
    {
        public T Value { get; set; }
        object IHasValue.Value
        {
             get { return this.Value; }
             set { this.Value = (T)value; }
        }
        public abstract void Increment();
        public abstract void Decrement();
    }
    class NumericUpDownControl : UpDownValueControl<decimal>
    {
        public override void Increment() { Value++; }
        public override void Decrement() { Value--; }
        //rest of the implementation
    }
    class TrackbarControl : UpDownValueControl<int>
    {
        public override void Increment() { Value++; }
        public override void Decrement() { Value--; }
        //rest of the implementation
    }
