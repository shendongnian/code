    public partial class EnumEditor : CheckedListBox
    {
        public EnumEditor()
        {
            InitializeComponent();
            ItemCheck += EnumEditor_ItemCheck;
        }
        private object _value;
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Value");
                if (!value.GetType().IsEnum)
                    throw new ArgumentNullException("Value should be enumerable.");
                if (value.GetType().GetCustomAttributes(typeof(FlagsAttribute), false).Length == 0)
                    throw new ArgumentNullException("Value must be marked with [Flags].");
                _value = value;
                Rebuild();
            }
        }
        public event EventHandler<EnumValueChangeEventArgs> ValueChanged;
        protected virtual void OnValueChanged(object value)
        {
            EventHandler<EnumValueChangeEventArgs> valueChanged = ValueChanged;
            if (valueChanged != null)
                valueChanged(this, new EnumValueChangeEventArgs { Value = value });
        }
        private void Rebuild()
        {
            Items.Clear();
            if (_value != null)
            {
                foreach (object value in Enum.GetValues(_value.GetType()))
                    Items.Add(value, ((int)_value & (int)value) != 0);
            }
        }
        void EnumEditor_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ulong bits = Convert.ToUInt64(_value);
            ulong bit = Convert.ToUInt64(Items[e.Index]);
            if (e.NewValue == CheckState.Checked)
                bits = bits | bit;
            else
                bits = bits & ~bit;
            _value = Enum.ToObject(_value.GetType(), bits);
            OnValueChanged(_value);
        }
    }
    public class EnumValueChangeEventArgs : EventArgs
    {
        public object Value
        {
            get;
            set;
        }
    }
