    public class TextBoxSelectAllOnFocusBehavior : Behavior<TextBox>
	{
		protected override void OnAttached()
		{
			base.OnAttached();
			this.AssociatedObject.GotMouseCapture += this.OnGotFocus;
			this.AssociatedObject.GotKeyboardFocus += this.OnGotFocus;
		}
		protected override void OnDetaching()
		{
			base.OnDetaching();
			this.AssociatedObject.GotMouseCapture -= this.OnGotFocus;
			this.AssociatedObject.GotKeyboardFocus -= this.OnGotFocus;
		}
		public void OnGotFocus(object sender, EventArgs args)
		{
			this.AssociatedObject.SelectAll();
		}
	}
