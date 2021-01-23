    public partial class EnumEditor : CheckedListBox
    {
        public EnumEditor()
        {
            InitializeComponent();
            ItemCheck += EnumEditor_ItemCheck;
        }
        private object _Value;
        public object Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Value");
                if (!value.GetType().IsEnum)
                    throw new ArgumentNullException("Value should be enumerable.");
                if (value.GetType().GetCustomAttributes(typeof(FlagsAttribute), false).Length == 0)
                    throw new ArgumentNullException("Value must be marked with [Flags].");
                _Value = value;
                Rebuild();
            }
        }
        private void Rebuild()
        {
            Items.Clear();
            if (_Value != null)
            {
                foreach (object value in Enum.GetValues(_Value.GetType()))
                    Items.Add(value, ((int)_Value & (int)value) != 0);
            }
        }
        void EnumEditor_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                _Value = (int)_Value | (int)Items[e.Index];
            else
                _Value = (int)_Value & ~(int)Items[e.Index];
        }
    }
