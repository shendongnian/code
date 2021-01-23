    public class MyCustomBinding
        : MvxBaseAndroidTargetBinding
    {
        private readonly TextView _textView;
        public MyCustomBinding(TextView textView)
        {
            _textView = textView;
        }
        public override void SetValue(object value)
        {
            var colorValue = (Color)value;
            _textView.SetTextColor(colorValue);
        }
        public override Type TargetType
        {
            get { return typeof(Color); }
        }
        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneWay; }
        }
    }
