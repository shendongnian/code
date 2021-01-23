    public class B
    {
        public B(A a)
        {
            IsResizeCancel = a.IsResizeCancel;
            MaxSliderValue = a.MaxSliderValue;
        }
        public bool IsResizeCancel { get; set; }
        public double MaxSliderValue { get; set; }
    }
