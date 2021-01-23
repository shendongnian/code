    internal class ContactcControlPropertySetter : Behavior<ContentControl>
    {
        protected override void OnAttached() {
            base.OnAttached();
            if (AssociatedObject == null)
                throw new InvalidOperationException("AssociatedObject must not be null");
            AssociatedObject.DataContextChanged += OnDataContextChanged;
            CultureManager.UICultureChanged += OnCultureChanged;
        }
        protected override void OnDetaching() {
            AssociatedObject.DataContextChanged -= OnDataContextChanged;
            CultureManager.UICultureChanged -= OnCultureChanged;
        }
        private void OnCultureChanged(object sender, EventArgs e) {
            SetProperties();
        }
        private void SetProperties()
        {
			...
            var tooltipFmt = _resourceManager.GetString(key, culture);
 			...
            AssociatedObject.ToolTip = tooltip;
 			...
        }
