    public class ToolTipEx : ToolTip
    {
        private readonly FrameworkElement _coreParent;
        static ToolTipEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolTipEx), new FrameworkPropertyMetadata(typeof(ToolTipEx)));
        }
        public ToolTipEx(FrameworkElement parent)
        {
            _coreParent = parent;
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var method = typeof(FrameworkElement).GetMethod("AddLogicalChild", BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(_coreParent, new object[] { Parent });
        }
    }
