    partial class MyClass
    {
        public int this[int channel]
        {
            get
            {
                return this.GetValue(channel);
            }
            set
            {
                this.SetValue(channel, value);
            }
        }
    }
