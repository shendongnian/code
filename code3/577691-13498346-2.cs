    public class FocusBehavior : Behavior<Control>
	{
		protected override void OnAttached()
		{
			base.OnAttached();
			this.AssociatedObject.Loaded += AssociatedObject_Loaded;
		}
		protected override void OnDetaching()
		{
			base.OnDetaching();
			this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
		}
		public void AssociatedObject_Loaded(object sender, EventArgs args)
		{
			this.AssociatedObject.Focus();
		}
	}
