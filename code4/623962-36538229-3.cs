    public sealed class PressAndHoldButton : Button
    {
        public event EventHandler PointerPressPreview = delegate { };
        protected override void OnPointerPressed(PointerRoutedEventArgs e)
        {
            PointerPressPreview(this, EventArgs.Empty);
            base.OnPointerPressed(e);
        }
    }
