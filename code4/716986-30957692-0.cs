    public class UIButtonTextBinding : MvxTargetBinding
    {
        public const string Property = "ButtonText";
        protected UIButton View
        {
            get { return Target as UIButton; }
        }
        public UIButtonTextBinding(UIButton target)
            : base(target)
        {
        }
        public override void SetValue(object value)
        {
            var view = View;
            if (view == null)
                return; 
            var stringValue = value as string;
            view.SetTitle(stringValue, UIControlState.Normal);
        }
        public override Type TargetType
        {
            get { return typeof(string); }
        }
        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneWay; }
        }
    }
